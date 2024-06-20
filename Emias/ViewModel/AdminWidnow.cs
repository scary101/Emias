using API6.Models;
using Emias.Interfaces;
using Emias.Service;
using Emias.View;
using Emias.ViewModel.Helpers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Xml.Linq;


namespace Emias.ViewModel
{
    class AdminWidnow : BindingHelpers
    {
        //Добавление реализуется через "-" даанные-данные-данные-данные
        //удаление: просто указать id  первые 5 записей в Patietns и Doctors не удаляются хз почему(Скорее всего они както-привязаны через ключи бд мешает их удалть)
        //Изменение В Doctors и Admins надо 2 раза ввсети id напрмер : 1-1-данныедляизменения-данныедляизменения-данныедляизменения 
        // для Patients id вводятся один раз (Как я понял из-за того что там первичный ключ не Identitty)
        // и дату там тоже надо будет подправить(Она будет выглядить так -2000-1-22- а должна будте так 2000/1/22

        // Штука для привязок метода
        public RelayCommand AddNew { get; set; }
        public RelayCommand Update { get; set; }
        public RelayCommand Vuvuod_v_datagrid { get; set; }
        public RelayCommand Delete_po_id { get; set; }




        // Штука для выбора строк для DataGrid
        private object _selectedItem;
        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                UpdateSecondTextBox();
            }
        }
       
        private List<object> _data;
        public List<object> Data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }


        private List<Admin> _admin;
        public List<Admin> _Admin
        {
            get { return _admin; }
            set
            {
                _admin = value;
                OnPropertyChanged(nameof(_Admin));
            }
        }
        private List<Doctor> _doc;
        public List<Doctor> _Doc
        {
            get { return _doc; }
            set
            {
                _doc = value;
                OnPropertyChanged(nameof(_Doc));
            }
        }
        private List<Patient> _pat;
        public List<Patient> _Pat
        {
            get { return _pat; }
            set
            {
                _pat = value;
                OnPropertyChanged(nameof(_Pat));
            }
        }







        // Значения по умолчанию 
        private string _name = "Название таблицы для вывода таблицы";
        public string NameofTable
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(NameofTable)); }
        }
        private string nadpisnaTextBox = "Введите данные для взаимодействия с базами данных";
        public string Second_TextBox
        {
            get { return nadpisnaTextBox; }
            set { nadpisnaTextBox = value; OnPropertyChanged(nameof(Second_TextBox)); }
        }

        public AdminWidnow()
        {
            // Переменыы для привязки к кнопкам


            Vuvuod_v_datagrid = new RelayCommand(_ => Vuvod());
            Delete_po_id = new RelayCommand(_ => Del_po_id());
            AddNew = new RelayCommand(AddNeww);
            Update = new RelayCommand(_ => UpdateData());





        }

        // Метод для удаления по id  
        private async void Del_po_id()
        {
            var id = int.Parse(Second_TextBox);
            if (_name == "Admins")
            {



                await DeleteAdmin(id);


            }
            else if (_name == "Doctors")
            {
                await DeleteDoctor(id);
            }
            else if (_name == "Patients")
            {
                await DeletePatient(id);
            }
        }

        // метод для выгрузи данных
        public async void Vuvod()
        {
            if (_name == "Admins")
            {

                await LoadAdmins();

            }
            else if (_name == "Doctors")
            {
                await LoadDoctors();
            }
            else if (_name == "Patients")
            {
                await LoadPat();
            }
        }
        // Метод что бы тыкнув на строку в Датагрид она написалась в Текстбокс
        private void UpdateSecondTextBox()
        {
            if (SelectedItem is Admin admin)
            {
                Second_TextBox = $"{admin.Surname}-{admin.Name}-{admin.Patronymic}-{admin.EnterPassword}";
            }
            else if (SelectedItem is Doctor doctor)
            {
                Second_TextBox = $"{doctor.Surname}-{doctor.Name}-{doctor.Patronymic}-{doctor.IdSpeciality}-{doctor.EnterPassword}-{doctor.WorkAdderss}";
            }
            else if (SelectedItem is Patient patient)
            {
                Second_TextBox = $"{patient.Oms}-{patient.Surname}-{patient.Name}-{patient.Patronymic}-{patient.BirthDate.ToString("yyyy-MM-dd")}-{patient.Address} {patient.LivingAddress} {patient.Phone} {patient.Email} {patient.Nickname}";
            }
        }
        // метод для добавления
        private async void AddNeww(object obj)
        {
            if (_name == "Admins")
            {

                string[] inputData = Second_TextBox.Split('-');
                string surname = inputData[0];
                string name = inputData[1];
                string patronymic = inputData[2];
                string password = inputData[3];


                var admin = new Admin
                {
                    Surname = surname,
                    Name = name,
                    Patronymic = patronymic,
                    EnterPassword = password
                };

                var apiService = new ApiService();
                await apiService.AddDataAsync<Admin>("api/Admins", admin);
                await LoadAdmins();
            }
            if (_name == "Patients")
            {
                string[] inputData = Second_TextBox.Split('-');
                string oms = inputData[0];
                string surname = inputData[1];
                string name = inputData[2];
                string patronymic = inputData[3];
                string bithdate = inputData[4];
                string address = inputData[5];
                string livingaddress = inputData[6];
                string phone = inputData[7];
                string email = inputData[8];
                string nickname = inputData[9];



                var pat = new Patient
                {
                    Oms = Convert.ToInt64(oms),
                    Surname = surname,
                    Name = name,
                    Patronymic = patronymic,
                    BirthDate = Convert.ToDateTime(bithdate),
                    Address = address,
                    LivingAddress = livingaddress,
                    Phone = phone,
                    Email = email,
                    Nickname = nickname
                };





                var apiService = new ApiService();
                await apiService.AddDataAsync<Patient>("api/Patients", pat);
                await LoadPat();
            }
            if (_name == "Doctors")
            {
                string[] inputData = Second_TextBox.Split('-');
                string surname = inputData[0];
                string name = inputData[1];
                string patronymic = inputData[2];
                string idSpeciality = inputData[3];
                string enterpassword = inputData[4];
                string workadderss = inputData[5];



                var docc = new Doctor
                {

                    Surname = surname,
                    Name = name,
                    Patronymic = patronymic,
                    IdSpeciality = Convert.ToInt32(idSpeciality),
                    EnterPassword = enterpassword,
                    WorkAdderss = workadderss


                };





                var apiService = new ApiService();
                await apiService.AddDataAsync<Doctor>("api/Doctors", docc);
                await LoadDoctors();
            }

        }




        // Методы для загрузка данных. В отдельных методах т.к я постаянно их вызываю
        private async Task LoadAdmins()
        {
            var apiService = new ApiService();
            var admins = await apiService.GetDataAsync<Admin>("api/Admins");
            _Admin = admins;
            Data = admins.Cast<object>().ToList();
        }
        private async Task LoadDoctors()
        {
            var apiService = new ApiService();
            var doct = await apiService.GetDataAsync<Doctor>("api/Doctors");
            _Doc = doct;
            Data = doct.Cast<object>().ToList();
        }
        private async Task LoadPat()
        {
            var apiService = new ApiService();
            var patt = await apiService.GetDataAsync<Patient>("api/Patients");
            _Pat = patt;
            Data = patt.Cast<object>().ToList();
        }
        // Методы для удаления
        private async Task DeleteAdmin(int id)
        {
            var apiService = new ApiService();
            await apiService.DeleteDataAsync<Admin>("api/Admins", id);
            await LoadAdmins();
        }

        private async Task DeleteDoctor(int id)
        {
           
            var apiService = new ApiService();
            await apiService.DeleteDataAsync<Doctor>($"api/Doctors" , id);
            await LoadDoctors();
        }

        private async Task DeletePatient(int id)
        {
            var apiService = new ApiService();
            await apiService.DeleteDataAsync<Patient>("api/Patients", id);
            await LoadPat();
        }
        // Метод для изменения
        private async void UpdateData()
        {
            if (_name == "Admins")
            {

                if (SelectedItem is Admin admin)
                {
                    string[] inputData = Second_TextBox.Split('-');

                    admin.IdAdmin = Convert.ToInt32(inputData[0]);
                    admin.Surname = inputData[1];
                    admin.Name = inputData[2];
                    admin.Patronymic = inputData[3];
                    admin.EnterPassword = inputData[4];

                    var apiService = new ApiService();
                    try
                    {
                        await apiService.UpdateDataAsync($"api/Admins/{admin.IdAdmin}", admin);
                        await LoadAdmins();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}");
                    }
                }
            }

            else if (_name == "Doctors")
            {   
                
                    if (SelectedItem is Doctor doctor)
                    {
                        string[] inputData = Second_TextBox.Split('-');
                        doctor.IdDoctor = Convert.ToInt32(inputData[0]);
                        doctor.Surname = inputData[1];
                        doctor.Name = inputData[2];
                        doctor.Patronymic = inputData[3];
                        doctor.IdSpeciality = Convert.ToInt32(inputData[4]);
                        doctor.EnterPassword = inputData[5];
                        doctor.WorkAdderss = inputData[6];

                        var apiService = new ApiService();
                        try
                        {
                            await apiService.UpdateDataAsync($"api/Doctors/{doctor.IdDoctor}", doctor);
                            await LoadDoctors();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}");
                        }
                    }
                
            }
            else if (_name == "Patients")
            {

                if (SelectedItem is Patient patient)
                {
                    string[] inputData = Second_TextBox.Split('-');
                    patient.Oms = Convert.ToInt32(inputData[0]);
                    patient.Surname = inputData[1];
                    patient.Name = inputData[2];
                    patient.Patronymic = inputData[3];
                    patient.BirthDate = Convert.ToDateTime(inputData[4]);
                    patient.Address = inputData[5];
                    patient.LivingAddress = inputData[6];
                    patient.Phone = inputData[7];
                    patient.Email = inputData[8];
                    patient.Nickname = inputData[9];
                


                    var apiService = new ApiService();
                    try
                    {
                        await apiService.UpdateDataAsync($"api/Patients/{patient.Oms}", patient);
                        await LoadPat();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}");
                    }
                }

            }


        }
    }
}






