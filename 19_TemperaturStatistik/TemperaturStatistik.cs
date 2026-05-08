namespace _19_TemperaturStatistik
{
    internal class TemperaturStatistik
    {
        private List<double> _messwerte = new List<double>();

        public void NeueMessungErfassen(double wert)
        {
            _messwerte.Add(wert);
        }

        public double Durchschnitt()
        {
            // return _messwerte.Average();  // easy way
            if (_messwerte.Count == 0)
            {
                Console.WriteLine("FEHLER: Keine Messwerte vorhanden!");
                return 0;
            }
            double sum = 0;
            foreach (var item in _messwerte)
            {
                sum += item;
            }
            return sum / _messwerte.Count;
        }

        public double Maximalwert()
        {
            if (_messwerte.Count == 0)
            {
                Console.WriteLine("FEHLER: Keine Messwerte vorhanden!");
                return 0;
            }
            // return _messwerte.Max();  // easy way
            double max = _messwerte[0];
            for (int i = 1; i < _messwerte.Count; i++)
            {
                max = _messwerte[i] > max ? _messwerte[i] : max;
            }
            return max;
        }
    }
}
