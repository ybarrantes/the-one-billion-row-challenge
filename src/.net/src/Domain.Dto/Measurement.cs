namespace Domain.Dto;

public class Measurement
{
    private decimal _maximum = decimal.MinValue;
    private decimal _minimum = decimal.MaxValue;
    private decimal _sum = 0;
    private uint _count = 0;
    
    public Measurement(decimal value)
    {
        UpdateMeasurement(value);
    }
    
    public decimal Average => _count == 0 ? 0 : (_maximum + _minimum) / 2;
    public uint Count => _count;
    public decimal Maximum => _maximum;
    public decimal Minimum => _minimum;
    public decimal Sum => _sum;
    
    public void UpdateMeasurement(decimal value)
    {
        _count++;
        
        if (value > _maximum)
        {
            _maximum = value;
        }
        
        if (value < _minimum)
        {
            _minimum = value;
        }

        _sum += value;
    }
    
    public override string ToString()
    {
        return $"{Minimum}/{Maximum}/{Count}/{Sum}";
    }
}