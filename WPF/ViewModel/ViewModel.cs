﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Data;
using System.Windows.Input;

namespace CaptionSummaryCustomization
{
    public class ViewModel : INotifyPropertyChanged
    {
        List<ICommand> commandList = new List<ICommand>();

        public List<ICommand> CommandList
        {
            get
            {
                return commandList;
            }
            set
            {
                commandList = value;
                OnPropertyChanged("CommandList");
            }
        }
        public ViewModel()
        {
            this.Employees = GetEmployeesDetails(100);
            CommandList.Add(IncreaseCommand);
            IncreaseCommand = new SummaryCommand(OnCaptionSummaryClicked);
        }

        private ICommand _IncreaseCommand;

        public ICommand IncreaseCommand
        {
            get
            {
                return _IncreaseCommand;
            }
            set
            {
                _IncreaseCommand = value;
                OnPropertyChanged("IncreaseCommand");
            }
        }

        private ObservableCollection<BusinessObjects> employees;

        public ObservableCollection<BusinessObjects> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                OnPropertyChanged("Employees");
            }
        }

        private static void OnCaptionSummaryClicked(object obj)
        {
            var items = ((object[])obj);
            var summaryRecord = items[1] as GridRecordContextMenuInfo;
            var group = items[1] as Group;
            if(group == null)
            {
                group = summaryRecord?.Record as Group;
            }
            if (group != null)
            {
                BusinessObjects groupInstrumentNode = null;
                if (group.Records is null)
                {
                    //groupInstrumentNode = group.Groups[0].Source?[0] as BusinessObjects;
                }
                else
                {
                    //groupInstrumentNode = group.Records?[0].Data as BusinessObjects;
                }
            }
        }

        private int number = 0;

        public ObservableCollection<BusinessObjects> GetEmployeesDetails(int count)
        {
            if (ComboBoxItemsSource == null)
            {
                _comboBoxItemsSource = new ObservableCollection<string>();
                for (int i = 0; i < countries.Count(); i++)
                {
                    _comboBoxItemsSource.Add(countries[i]);
                }
            }
            var employees = new ObservableCollection<BusinessObjects>();
            for (int i = 1; i < count; i++)
            {
                employees.Add(GetEmployee(i));
                number++;
            }
            return employees;
        }

        private ObservableCollection<string> _comboBoxItemsSource;

        public ObservableCollection<string> ComboBoxItemsSource
        {
            get { return _comboBoxItemsSource; }
            set
            {
                _comboBoxItemsSource = value;
                OnPropertyChanged("ComboBoxItemsSource");
            }
        }

        public BusinessObjects GetEmployee(int i)
        {
            number = number < 10 ? number++ : 1;
            return new BusinessObjects()
            {
                EmployeeName = names[number],
                EmployeeArea = ComboBoxItemsSource.ElementAt(number),
                EmployeeGender = number%3 != 0 ? "Male" : "Female",
                EmployeeSalary = 1000 + i,
                ContactNumber = "97788090" + number.ToString(),
                JoiningDate = DateTime.Now.AddDays(1000 + i)
            };
        }

        private string[] names = new string[]
        {
            "Robert",
            "John",
            "clarke",
            "Mathews",
            "Smith",
            "Martin",
            "Inigo",
            "Antony",
            "Micheal",
            "Anderson",
            "Alastair",
            "Kevin",
            "Alex",
            "Hussain",
            "Hughes",
            "Andrews",
        };

        private string[] countries = new string[]
        {
            "Brazil",
            "Germany",
            "France",
            "Japan",
            "China",
            "Ireland",
            "Argentina",
            "England",
            "Brazil",
            "Germany",
            "France",
            "Japan",
            "China",
            "Ireland",
            "Argentina",
            "England",
            "Brazil",
            "Germany",
            "France",
            "Japan",
            "China",
            "Ireland",
            "Argentina",
            "England"
        };

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
