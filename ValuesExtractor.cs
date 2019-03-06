namespace ArktiPhones
{
    public class ValuesExtractor
    {
        private ArktiPhones.Data _phone { get; set; }
        public ValuesExtractor(ArktiPhones.Data phone)
        {
            _phone = phone;
        }
        public string miliAmps()
        {
            // Battery
                _phone.Auxiliary.BatteryInMiliAh = phone.Overview.Battery?.Capacity != null ? double.Parse(Regex.Replace(phone.Overview.Battery?.Capacity, "[^0-9+-]", "")) : double.NaN;
               
        }
    }
}