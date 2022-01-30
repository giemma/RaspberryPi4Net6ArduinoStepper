using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryPi4Net6ArduinoStepper
{
    public class GpioClass : IDisposable
    {
        int pinShow = 20;
        int pinHide = 21;

        GpioController gpio;
        public GpioClass()
        {
            gpio = new GpioController();

            gpio.OpenPin(pinShow, PinMode.Output);
            gpio.OpenPin(pinHide, PinMode.Output);

            gpio.Write(pinShow, PinValue.Low);
            gpio.Write(pinHide, PinValue.Low);
        }

        public async Task ShowFlag()
        {
            gpio.Write(pinShow, PinValue.High);
            await Task.Delay(50);
            gpio.Write(pinShow, PinValue.Low);
        }

        public async Task HideFlag()
        {
            gpio.Write(pinHide, PinValue.High);
            await Task.Delay(50);
            gpio.Write(pinHide, PinValue.Low);
        }

        public void Dispose()
        {
            gpio.Write(pinShow, PinValue.Low);
            gpio.Write(pinHide, PinValue.Low);
            gpio.Dispose();
        }
    }
}
