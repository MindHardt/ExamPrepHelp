using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helping
{
    public record Order
    {
        //Properties are nullable to ensure that all data is provided, ctor ensures that they're not null.
        public string? Name { get; } //Starts with uppercase
        public DateOnly? Date { get; } //Dateformat
        public string? Good { get; } //Starts with lowercase
        public float? Weight { get; } //Is a float

        public override string ToString() => $"{Name};" + 
            $"{Date!.Value.ToString("dd-MM-yyyy")};" + //Formatting as DD-MM-YYYY
            $"{char.ToUpper(Good![0]) + Good![1..]};" + //Forcing 1st letter to be uppercase
            $"{Weight}";

        public Order(string line)
        {
            string[] parts = line.Split(' ');

            foreach (string part in parts)
            {
                char firstChar = part[0];
                if (char.IsUpper(firstChar)) //If name
                {
                    Name = part;
                    continue;
                }

                if (char.IsLower(firstChar)) //If good
                {
                    Good = part;
                    continue;
                }

                if (float.TryParse(part.ToLower().Replace("кг", string.Empty).Trim(), out float weight)) //If weight
                {
                    Weight = weight;
                    continue;
                }

                if (DateOnly.TryParse(part, out DateOnly date)) //If date
                {
                    Date = date;
                    continue;
                }
            }

            if (Name is null || Good is null || Date is null || Weight is null) throw new FormatException();
        }
    }
}
