using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using MicrowaveOvenController.Commands;
using MicrowaveOvenController.Interfaces;
using MicrowaveOvenController.Models;

namespace MicrowaveOvenController.ViewModels
{
    public class MicrowaveOvenControllerViewModel : IMicrowaveOvenHW, INotifyPropertyChanged
    {
        private MicrowaveOvenControlPanel _microwaveOvenControlPanel;

        public bool DoorOpen
        {
            get
            {
                return _microwaveOvenControlPanel.DoorOpen;
            }
            set
            {
                _microwaveOvenControlPanel.DoorOpen = value;
                OnPropertyChanged(nameof(DoorOpen));
            }

        }

        public string Timer
        {
            get
            {
                return _microwaveOvenControlPanel.Timer;
            }
            set
            {
                _microwaveOvenControlPanel.Timer = value;
                OnPropertyChanged(nameof(Timer));
            }
        }

        public bool IsLightOn
        {
            get
            {
                return _microwaveOvenControlPanel.IsLightOn;
            }
            set
            {
                _microwaveOvenControlPanel.IsLightOn = value;
                OnPropertyChanged(nameof(IsLightOn));
            }
        }

        public string LightMessage
        {
            get
            {
                return _microwaveOvenControlPanel.LightMessage;
            }
            set
            {
                _microwaveOvenControlPanel.LightMessage = value;
                OnPropertyChanged(nameof(LightMessage));
            }
        }

        private int increment;

        public event Action<bool> DoorOpenChanged;
        public event EventHandler StartButtonPressed;
        public event PropertyChangedEventHandler? PropertyChanged;

        public DispatcherTimer dispatcherTimer;

        public ICommand StartCommand {  get; }
        public ICommand DoorOpenChangeCommand { get; }

        public MicrowaveOvenControllerViewModel() 
        {
            _microwaveOvenControlPanel = new MicrowaveOvenControlPanel();
            _microwaveOvenControlPanel.Timer = "0";

            StartCommand = new RelayCommand(s => Start());
            DoorOpenChangeCommand = new RelayCommand(s => DoorOpenChange());
            DoorOpenChanged += OnDoorOpenChange;
            StartButtonPressed += OnStartButtonPressed;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += Decrement;
            TurnOffLight();
        }
        public void OnPropertyChanged(string property) =>
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        public void Start()
        {
            StartButtonPressed.Invoke(this, EventArgs.Empty);
        }

        public void DoorOpenChange()
        {
            DoorOpenChanged.Invoke(DoorOpen);
        }

        public void OnDoorOpenChange(bool doorOpenChanged)
        {
            DoorOpen = !doorOpenChanged;
            if (DoorOpen)
            {
                TurnOffHeater();
                TurnOnLight();
            }
            else
            {
                TurnOffLight();
            }
        }

        public void OnStartButtonPressed(object sender, EventArgs args)
        {
            if (!DoorOpen)
            {
                TurnOnHeater();
            }
        }

        public void Decrement(object sender, EventArgs e)
        {
            increment--;
            Timer = increment.ToString();
        }

        public void TurnOffHeater()
        {
            dispatcherTimer.Stop();
        }

        public void TurnOnHeater()
        {
            if (dispatcherTimer.IsEnabled)
            {
                increment = increment + 60;
                Timer = increment.ToString();
            }
            else if (increment > 0)
            {
                dispatcherTimer.Start();
            }
            else
            {
                increment = 60;
                dispatcherTimer.Start();
                Timer = increment.ToString();
            }
        }

        public void TurnOffLight()
        {
            IsLightOn = false;
            LightMessage = "Light is turned off";
        }

        public void TurnOnLight()
        {
            IsLightOn = true;
            LightMessage = "Light is turned on";
        }
    }
}
