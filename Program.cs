using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    //Перечисление для приоритетов 
    enum Employes { Manager, Supervisor, Worker };

    //Структура работника
    struct Work
    {
        public Employes Employ;
        public int ID;
        public int Time;

        public Work(Employes employes, int id, int time)
        {
            Employ = employes;
            ID = id;
            Time = time;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Создадим массив с беспорядочным расположением сотрудников
            Work[] empsRandom =
            {
                new Work(Employes.Manager,      100,    10),
                new Work(Employes.Supervisor,   101,    20),
                new Work(Employes.Worker,       102,    30),
                new Work(Employes.Manager,      103,    40),
                new Work(Employes.Supervisor,   104,    50),
                new Work(Employes.Manager,      105,    10),
                new Work(Employes.Manager,      106,    20),
                new Work(Employes.Worker,       107,    30),
                new Work(Employes.Supervisor,   108,    40),
                new Work(Employes.Worker,       109,    50)
            };

            //Запишем данные в файл
            Write(empsRandom);

            //Запичем данные в очередь приоритетов
            PQueue<Work> empsOrder = new PQueue<Work>();
            Read(empsOrder);

            //Запишем упорядоченные данные в файл
            int[] summTime = new int[3];
            Work item;
            using (StreamWriter Write = new StreamWriter("OrderList.txt"))
            {
                Write.WriteLine("Должность\t\tНомер\tВремя\n");

                while (!empsOrder.IsEmpty)
                {
                    item = empsOrder.PDequeue();

                    summTime[(int)item.Employ] += item.Time;

                    Write.WriteLine(Enum.GetName(item.Employ.GetType(), item.Employ).PadLeft(10)
                         + item.ID.ToString().PadLeft(10) + item.Time.ToString().PadLeft(5)); 
                }
                
                Write.WriteLine("\n");
                Write.WriteLine($"Manager       {summTime[(int)Employes.Manager]}");
                Write.WriteLine($"Worker        {summTime[(int)Employes.Worker]}");
                Write.WriteLine($"Supervisor    {summTime[(int)Employes.Supervisor]}");
            }
        }


        static void Write(Work[] emps)
        {
            FileInfo f = new FileInfo("work.txt");
            using (BinaryWriter bw = new BinaryWriter(f.OpenWrite()))
            {
                for (int i = 0; i < emps.Length; i++)
                {
                    bw.Write((int)emps[i].Employ);
                    bw.Write(emps[i].ID);
                    bw.Write(emps[i].Time);
                    bw.Write('\n');
                }
            }
        }

        static void Read(PQueue<Work> emps)
        {
            Work item = new Work(Employes.Manager, 0, 0);

            FileInfo f = new FileInfo("work.txt");
            using (BinaryReader br = new BinaryReader(f.OpenRead()))
            {
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    item.Employ = (Employes)br.ReadInt32();
                    item.ID = br.ReadInt32();
                    item.Time = br.ReadInt32();
                    br.BaseStream.Position++;

                    emps.PEnqueue((int)item.Employ, item); 
                }
            }
        }
    }
}
