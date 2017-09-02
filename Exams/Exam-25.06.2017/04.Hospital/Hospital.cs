namespace _04.Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Hospital
    {
        public static void Main()
        {
            var departmentWithPatients = new Dictionary<string, List<string>>();
            var doctorWithPatients = new Dictionary<string, List<string>>();

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "Output")
                {
                    break;
                }

                var tokens = inputLine.Split();

                var department = tokens[0];
                var doctor = tokens[1] + " " + tokens[2];
                var patient = tokens[3];

                if (!departmentWithPatients.ContainsKey(department))
                {
                    departmentWithPatients[department] = new List<string>();
                }

                if (departmentWithPatients[department].Count == 60)
                {
                    continue;
                }

                departmentWithPatients[department].Add(patient);

                if (!doctorWithPatients.ContainsKey(doctor))
                {
                    doctorWithPatients[doctor] = new List<string>();
                }

                doctorWithPatients[doctor].Add(patient);
            }

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                if (departmentWithPatients.ContainsKey(command))
                {
                    foreach (var patient in departmentWithPatients[command])
                    {
                        Console.WriteLine(patient);
                    }
                }
                else if (doctorWithPatients.ContainsKey(command))
                {
                    foreach (var patient in doctorWithPatients[command]
                        .OrderBy(x => x))
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    var tokens = command.Split();

                    var department = tokens[0];
                    var room = int.Parse(tokens[1]);

                    var patientsInRoom = departmentWithPatients[department].Skip((room * 3) - 3).Take(3).ToList();

                    foreach (var patient in patientsInRoom
                        .OrderBy(x => x))
                    {
                        Console.WriteLine(patient);
                    }
                }
            }
        }
    }
}