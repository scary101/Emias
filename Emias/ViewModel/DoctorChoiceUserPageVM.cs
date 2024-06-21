using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using API6.Models;
using Emias.Interfaces;
using Emias.Model;
using Emias.Service;
using Emias.ViewModel.Helpers;
using Emias.View;
using System.Runtime.CompilerServices;
using Emias;
using System.Windows;
using System.Windows.Navigation;

public class DoctorChoiceUserPageVM : BindingHelpers
{
    private DaySlot _selectedDaySlot;
    private TimeSlot _selectedTimeSlot;
    private int _vrachType;
    private List<Appointment> fullappointments { get; set; }
    private List<Doctor> doctors;

    private INavigationService _navigationService;
    public ObservableCollection<TimeSlot> MorningSlots { get; set; }
    public ObservableCollection<TimeSlot> DaySlots { get; set; }
    public ObservableCollection<TimeSlot> EveningSlots { get; set; }
    public ObservableCollection<DaySlot> CurrentWeekDays { get; set; }
    public ObservableCollection<DaySlot> NextWeekDays { get; set; }

    public ObservableCollection<DoktorInfoCardUS> Doctors { get; set; }

    public GenericRelyaCommand<TimeSlot> SelectTimeSlotCommand { get; set; }
    public GenericRelyaCommand<DaySlot> SelectDaySlotCommand { get; set; }

    public TimeSlot SelectedTimeSlot
    {
        get { return _selectedTimeSlot; }
        set
        {
            if (_selectedTimeSlot != value)
            {
                if (_selectedTimeSlot != null)
                {
                    _selectedTimeSlot.IsSelected = false;
                }
                _selectedTimeSlot = value;
                if (_selectedTimeSlot != null)
                {
                    _selectedTimeSlot.IsSelected = true;
                }
                OnPropertyChanged(nameof(SelectedTimeSlot));
            }
        }
    }

    private DoktorInfoCardUS _seldoctor;
    public DoktorInfoCardUS SelDoctor
    {
        get { return _seldoctor; } set { _seldoctor = value; OnPropertyChanged(nameof(SelDoctor)); } 
    }


    private DateTime _selectDate;

    public DateTime SelectDate
    {
        get { return _selectDate; }
        set { _selectDate = value; OnPropertyChanged(nameof(SelectDate)); }
    }

    public DaySlot SelectedDaySlot
    {
        get { return _selectedDaySlot; }
        set
        {
            if (_selectedDaySlot != value)
            {
                if (_selectedDaySlot != null)
                {
                    _selectedDaySlot.IsSelected = false;
                }
                _selectedDaySlot = value;
                if (_selectedDaySlot != null)
                {
                    _selectedDaySlot.IsSelected = true;
                }
                OnPropertyChanged(nameof(SelectedDaySlot));
                LoadTimeSlotsForSelectedDay();
            }
        }
    }
    public RelayCommand ZapisZapis { get; set; }
    public RelayCommand GoToMainMenu { get; set; }

    public DoctorChoiceUserPageVM(INavigationService navigation, SelectVrachCardType vrachType)
    {
        _vrachType = (int)vrachType;
        _navigationService = navigation ?? throw new ArgumentNullException(nameof(navigation));
        Doctors = new ObservableCollection<DoktorInfoCardUS>();
        doctors = new List<Doctor>();
        MorningSlots = new ObservableCollection<TimeSlot>();
        DaySlots = new ObservableCollection<TimeSlot>();
        EveningSlots = new ObservableCollection<TimeSlot>();
        CurrentWeekDays = new ObservableCollection<DaySlot>();
        NextWeekDays = new ObservableCollection<DaySlot>();

        ZapisZapis = new RelayCommand(_ => PutData());
        GoToMainMenu = new RelayCommand(_ => MainMenu());
        SelectTimeSlotCommand = new GenericRelyaCommand<TimeSlot>(SelectTimeSlot);
        SelectDaySlotCommand = new GenericRelyaCommand<DaySlot>(SelectDaySlot);

        LoadData();
    }

    private async void LoadData()
    {
        await LoadZapis();
        await LoadDoctors();
        InitializeDefaultSelections();
    }

    private async Task LoadZapis()
    {
        var apiService = new ApiService();
        var fullappont = await apiService.GetDataAsync<Appointment>("api/Appointments");
        fullappointments = fullappont;
    }

    private async Task LoadDoctors()
    {
        var apiService = new ApiService();
        var doc = await apiService.GetDataAsync<Doctor>("api/Doctors");
        doctors = doc.Where(j => j.IdSpeciality == _vrachType).ToList();
        foreach (var i in doctors)
        {
            string fullname = $"{i.Surname} {i.Name} {i.Patronymic}";
            Doctors.Add(new DoktorInfoCardUS(new DoctorInfo(fullname, i.WorkAdderss, "Сегодня")));
        }
    }

    private void InitializeDefaultSelections()
    {
        if (Doctors.Count > 0)
        {
            SelDoctor = Doctors[0];
        }

        AddDays(CurrentWeekDays, DateTime.Now);
        AddDays(NextWeekDays, DateTime.Now.AddDays(7));

        DaySlot todayDaySlot = CurrentWeekDays.FirstOrDefault(d => d.Day == DateTime.Now.ToString("dd MMM, ddd"));
        if (todayDaySlot != null)
        {
            SelectDaySlot(todayDaySlot);
        }
    }

    private void AddTimeSlots(ObservableCollection<TimeSlot> slots, TimeSpan startTime, TimeSpan endTime, TimeSpan interval)
    {
        for (var time = startTime; time < endTime; time += interval)
        {
            slots.Add(new TimeSlot { Time = time.ToString(@"hh\:mm") });
        }
    }

    private void AddDays(ObservableCollection<DaySlot> days, DateTime startDate)
    {
        for (int i = 0; i < 7; i++)
        {
            days.Add(new DaySlot { Day = startDate.AddDays(i).ToString("dd MMM, ddd") });
        }
    }

    private void SelectTimeSlot(TimeSlot selectedTimeSlot)
    {
        if (selectedTimeSlot != null)
        {
            foreach (var slot in MorningSlots.Concat(DaySlots).Concat(EveningSlots))
            {
                slot.IsSelected = false;
            }
            selectedTimeSlot.IsSelected = true;
            SelectedTimeSlot = selectedTimeSlot;
        }
    }

    private void SelectDaySlot(DaySlot selectedDaySlot)
    {
        if (selectedDaySlot != null)
        {
            foreach (var day in CurrentWeekDays.Concat(NextWeekDays))
            {
                day.IsSelected = false;
            }
            selectedDaySlot.IsSelected = true;
            SelectedDaySlot = selectedDaySlot;
        }
    }

    private void LoadTimeSlotsForSelectedDay()
    {
        if (SelectedDaySlot == null || SelDoctor == null) return;

        MorningSlots.Clear();
        DaySlots.Clear();
        EveningSlots.Clear();

        SelectDate = DateTime.ParseExact(SelectedDaySlot.Day, "dd MMM, ddd", CultureInfo.CurrentCulture);

        AddTimeSlots(MorningSlots, new TimeSpan(8, 0, 0), new TimeSpan(12, 0, 0), new TimeSpan(0, 20, 0));
        AddTimeSlots(DaySlots, new TimeSpan(12, 10, 0), new TimeSpan(16, 0, 0), new TimeSpan(0, 20, 0));
        AddTimeSlots(EveningSlots, new TimeSpan(17, 10, 0), new TimeSpan(20, 0, 0), new TimeSpan(0, 20, 0));

        var doc = doctors[Doctors.IndexOf(SelDoctor)];
        var occupiedSlots = fullappointments
            .Where(a => a.IdDoctor == doc.IdDoctor && a.AppointmentDate == SelectDate)
            .Select(a => a.AppointmentTime)
            .ToList();

        RemoveOccupiedTimeSlots(MorningSlots, occupiedSlots);
        RemoveOccupiedTimeSlots(DaySlots, occupiedSlots);
        RemoveOccupiedTimeSlots(EveningSlots, occupiedSlots);
    }

    private void RemoveOccupiedTimeSlots(ObservableCollection<TimeSlot> slots, List<TimeSpan> occupiedSlots)
    {
        for (int i = slots.Count - 1; i >= 0; i--)
        {
            var slotTime = TimeSpan.ParseExact(slots[i].Time, @"hh\:mm", CultureInfo.InvariantCulture);
            if (occupiedSlots.Contains(slotTime))
            {
                slots.RemoveAt(i);
            }
        }
    }



    private async Task PutZapis(Appointment zapis)
    {
        var apiServise = new ApiService();

        await apiServise.AddDataAsync<Appointment>("api/Appointments", zapis);
    }

    private void PutData()
    {
        if(_selectedTimeSlot != null)
        {
            string timeString = _selectedTimeSlot.Time;
            TimeSpan selectedTime = TimeSpan.ParseExact(timeString, @"hh\:mm", CultureInfo.InvariantCulture);
            var doc = doctors[Doctors.IndexOf(SelDoctor)];
            Appointment appointment = new Appointment(App.Patient.Oms, doc.IdDoctor, _selectDate, selectedTime, 1);
            PutZapis(appointment);
        }
        else
        {
            MessageBox.Show("Выберите время!");
        }
    }
    private void MainMenu()
    {
        _navigationService.NavigateTo("MainMenuUserPage");
    }








}
