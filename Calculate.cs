using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculationForms
{
    public partial class Calculate : Form
    {
        public Calculate(List<double> args)
        {
            InitializeComponent();

            double[] inputData1 = { args[0], args[1], args[2], args[3],
                args[4], args[5], args[6], args[7], args[8] }; // h0 b0 l0 Rb f nв σ0 ∆h

            List<Result> results = new List<Result>();

            //Клеть №1
            int r = 2; // Сколько знаков после запятой

            double[] temporaryValues1 = new double[30];

            Console.WriteLine("\nПодсчёт для Клети №1\n");

            temporaryValues1[0] = inputData1[0] - inputData1[7];
            Result res = new Result("h1", "Высота полосы на выходе", "мм", Math.Round(temporaryValues1[0], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[1] = (0.4 * inputData1[7] * Math.Sqrt(inputData1[7] * inputData1[3])) / inputData1[0];
            res = new Result("delta_b", "Уширение", "мм", Math.Round(temporaryValues1[1], 2));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[2] = inputData1[1] + temporaryValues1[1];
            res = new Result("b1", "Ширина полосы на выходе", "мм", Math.Round(temporaryValues1[2], 2));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[3] = inputData1[1] * inputData1[0];
            res = new Result("S0", "Площадь сечения полосы до прокатки", "мм^2", Math.Round(temporaryValues1[3], 2));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[4] = temporaryValues1[0] * temporaryValues1[2];
            res = new Result("S1", "Площадь сечения полосы после прокатки", "мм^2", Math.Round(temporaryValues1[4], 2));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[5] = temporaryValues1[3] / temporaryValues1[4];
            res = new Result("l'ambda", "Вытяжка за проход", "–", Math.Round(temporaryValues1[5], 2));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[6] = inputData1[2] * temporaryValues1[5];
            res = new Result("l1", "Длина полосы на выходе из клети", "мм", Math.Round(temporaryValues1[6], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[7] = 1 - temporaryValues1[0] / inputData1[0];
            res = new Result("epsilon", "Степень деформации", "–", Math.Round(temporaryValues1[7], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[8] = Math.Acos(1 - inputData1[7] / (2 * inputData1[3]));
            res = new Result("alfa_0", "Угол захвата полосы", "rad", Math.Round(temporaryValues1[8], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            if (Math.Tan(temporaryValues1[8]) <= inputData1[4]) Console.WriteLine("\nЗахват полосы успешен");
            else Console.WriteLine("\nНе выполнено условие захвата полосы");

            Console.WriteLine("\nРасчет энергосиловых параметров\n");

            temporaryValues1[9] = 1 - temporaryValues1[0] / inputData1[0];
            res = new Result("epsilon", "Средняя степень деформации", "–", Math.Round(temporaryValues1[9], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[10] = 0.105 * inputData1[5] * Math.Sqrt(temporaryValues1[9] * inputData1[3] / inputData1[0]);
            res = new Result("Uc", "Средняя скорость деформации", "–", Math.Round(temporaryValues1[10], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[11] = Math.Log(inputData1[0] / temporaryValues1[0]);
            res = new Result("epsilon_l", "Конечная логарифмическая степень деформации", "–", Math.Round(temporaryValues1[11], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[12] = inputData1[6] + 14.4 * Math.Pow(temporaryValues1[9], 0.83);
            res = new Result("sigma_sc", "Среднее сопротивление деформации", "МПа", Math.Round(temporaryValues1[12], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[13] = Math.Sqrt((inputData1[0] - temporaryValues1[0]) * inputData1[3]);
            res = new Result("l", "Длина очага деформации", "мм", Math.Round(temporaryValues1[13], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[14] = (inputData1[0] + temporaryValues1[0]) / 2;
            res = new Result("hc", "Средняя высота в очаге деформации", "мм", Math.Round(temporaryValues1[14], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[15] = Math.Pow(temporaryValues1[13] / temporaryValues1[14], -0.42);
            res = new Result("n_sigma", "Коэффициент напряжённого состояния", "–", Math.Round(temporaryValues1[15], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[16] = temporaryValues1[15] * temporaryValues1[12];
            res = new Result("pc", "Среднее удельное давление", "МПа", Math.Round(temporaryValues1[16], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[17] = ((inputData1[1] + temporaryValues1[2]) / 2) * Math.Sqrt((inputData1[0] + temporaryValues1[0]) * inputData1[3]);
            res = new Result("Fr", "Горизонтальная проекция площади контакта полосы с валками", "мм^2", Math.Round(temporaryValues1[17], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[18] = temporaryValues1[17] * temporaryValues1[16] / 1000;
            res = new Result("P", "Усилие прокатки", "кН", Math.Round(temporaryValues1[18], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[19] = temporaryValues1[18] * temporaryValues1[13] / 1000;
            res = new Result("Mв", "Момент на валках", "кН/м", Math.Round(temporaryValues1[19], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[20] = 0.3 * inputData1[6];
            res = new Result("sigma_н", "Удельное натяжение полосы", "МПа", Math.Round(temporaryValues1[20], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[21] = temporaryValues1[20] * inputData1[0] * inputData1[1];
            res = new Result("Tn", "Переднее натяжение полосы", "кН", Math.Round(temporaryValues1[21] / 1000, r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[22] = temporaryValues1[20] * temporaryValues1[0] * temporaryValues1[2];
            res = new Result("Tз", "Заднее натяжение полосы", "кН", Math.Round(temporaryValues1[22] / 1000, r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[23] = Math.PI * 2 * inputData1[3] * inputData1[5] / 60000;
            res = new Result("V01", "Скорость на входе", "м/с", Math.Round(temporaryValues1[23], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues1[24] = temporaryValues1[23] * temporaryValues1[5];
            res = new Result("V11", "Скорость на выходе", "м/с", Math.Round(temporaryValues1[24], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            for (int i = 0; i < 25; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = results[i].name + " | " + results[i].mark + " | "  + results[i].ci;
                dataGridView1.Rows[i].Cells[1].Value = results[i].value;
            }

            double[] dopValues1 = new double[20];

            List<Result> dopResults = new List<Result>();

            dopValues1[0] = temporaryValues1[18] * (0.36 - 0.0005 * inputData1[1]) / (3.2 * Math.Pow(10, -6) * Math.Pow(inputData1[3], 3));
            res = new Result("sigma_из.б.", "Максимальные напряжения изгиба в бочке валка", "МПа", Math.Round(dopValues1[0], r));
            dopResults.Add(res);

            dopValues1[1] = 0.390625 * temporaryValues1[18];
            res = new Result("sigma_из.ш.", "Максимальные изгибающие напряжения в шейке валка", "МПа", Math.Round(dopValues1[1], r));
            dopResults.Add(res);

            dopValues1[2] = 640 / dopValues1[0];
            res = new Result("nб", "Коэфф запаса прочности в б.в.", "МПа", Math.Round(dopValues1[2], r));
            dopResults.Add(res);

            dopValues1[3] = 640 / dopValues1[1];
            res = new Result("nш", "Коэфф запаса прочности в ш.в.", "МПа", Math.Round(dopValues1[3], r));
            dopResults.Add(res);

            dopValues1[4] = 0.2275 * temporaryValues1[18];
            res = new Result("sigma_см.г.", "Напр смятия на поверхности соприкосновения гайки", "МПа", Math.Round(dopValues1[4], r));
            dopResults.Add(res);

            dopValues1[5] = 0.0357 * temporaryValues1[18];
            res = new Result("sigma_см.", "Напряжение смятия резьбы гайки", "МПа", Math.Round(dopValues1[5], r));
            dopResults.Add(res);

            dopValues1[6] = 0.2958 * temporaryValues1[18];
            res = new Result("sigma_из.", "Напряжение смятия резьбы гайки", "МПа", Math.Round(dopValues1[6], r));
            dopResults.Add(res);

            dopValues1[7] = 400 / dopValues1[4];
            res = new Result("nсм.г.", "Коэфф запаса прочности для поверхности соприкосновения гайки с поперечиной станины", 
                "МПа", Math.Round(dopValues1[7], r));
            dopResults.Add(res);

            dopValues1[8] = 400 / dopValues1[5];
            res = new Result("nсм.", "Коэфф запаса прочности для резьбы гайки по напряжениям смятия",
                "МПа", Math.Round(dopValues1[8], r));
            dopResults.Add(res);

            dopValues1[9] = 400 / dopValues1[6];
            res = new Result("nиз.", "Коэфф запаса прочности для резьбы гайки по напряжениям изгиба",
                "МПа", Math.Round(dopValues1[9], r));
            dopResults.Add(res);

            dopValues1[10] = (0.046 * temporaryValues1[18] - 0.2) / 1.8;
            res = new Result("sigma_1", "Напряжение в нижней поперечине",
                "МПа", Math.Round(dopValues1[10], r));
            dopResults.Add(res);

            dopValues1[11] = (temporaryValues1[18] / 48) + 1.17;
            res = new Result("sigma_2", "Напряжение в стойках",
                "МПа", Math.Round(dopValues1[11], r));
            dopResults.Add(res);

            dopValues1[12] = (0.046 * temporaryValues1[18] - 0.2) / 18;
            res = new Result("sigma_3", "Напряжение в верхней поперечине",
                "МПа", Math.Round(dopValues1[12], r));
            dopResults.Add(res);

            dopValues1[13] = 600 / dopValues1[10];
            res = new Result("n1", "Коэфф запаса прочности для нижней поперечины",
                "-", Math.Round(dopValues1[13], r));
            dopResults.Add(res);

            dopValues1[14] = 600 / dopValues1[11];
            res = new Result("n2", "Коэфф запаса прочности для стойки",
                "-", Math.Round(dopValues1[14], r));
            dopResults.Add(res);

            dopValues1[15] = 600 / dopValues1[12];
            res = new Result("n3", "Коэфф запаса прочности для верхней поперечины",
                "-", Math.Round(dopValues1[15], r));
            dopResults.Add(res);

            for (int i = 25; i < 41; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dopResults[i - 25].name + " | " + dopResults[i - 25].mark + " | " + dopResults[i - 25].ci;
                dataGridView1.Rows[i].Cells[1].Value = dopResults[i - 25].value;
            }

            // Клеть №2

            double[] inputData2 = { temporaryValues1[0], temporaryValues1[2], temporaryValues1[6], args[3], args[4], args[5], args[6], args[8] }; // h0 b0 l0 Rb f nв σ0 ∆h

            double[] temporaryValues2 = new double[30];

            Console.WriteLine("\nПодсчёт для Клети №2\n");

            temporaryValues2[0] = inputData2[0] - inputData2[7];
            res = new Result("h1", "Высота полосы на выходе", "мм", Math.Round(temporaryValues2[0], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[1] = (0.4 * inputData2[7] * Math.Sqrt(inputData2[7] * inputData2[3])) / inputData2[0];
            res = new Result("delta_b", "Уширение", "мм", Math.Round(temporaryValues2[1], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[2] = inputData2[1] + temporaryValues2[1];
            res = new Result("b1", "Ширина полосы на выходе", "мм", Math.Round(temporaryValues2[2], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[3] = inputData2[1] * inputData2[0];
            res = new Result("S0", "Площадь сечения полосы до прокатки", "мм^2", Math.Round(temporaryValues2[3], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[4] = temporaryValues2[0] * temporaryValues2[2];
            res = new Result("S1", "Площадь сечения полосы после прокатки", "мм^2", Math.Round(temporaryValues2[4], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[5] = temporaryValues2[3] / temporaryValues2[4];
            res = new Result("l'ambda", "Вытяжка за проход", "–", Math.Round(temporaryValues2[5], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[6] = inputData2[2] * temporaryValues2[5];
            res = new Result("l1", "Длина полосы на выходе из клети", "мм", Math.Round(temporaryValues2[6], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[7] = 1 - temporaryValues2[0] / inputData2[0];
            res = new Result("epsilon", "Степень деформации", "–", Math.Round(temporaryValues2[7], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[8] = Math.Acos(1 - inputData2[7] / (2 * inputData2[3]));
            res = new Result("alfa_0", "Угол захвата полосы", "rad", Math.Round(temporaryValues2[8], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            if (Math.Tan(temporaryValues2[8]) <= inputData2[4]) Console.WriteLine("\nЗахват полосы успешен");
            else Console.WriteLine("\nНе выполнено условие захвата полосы");

            Console.WriteLine("\nРасчет энергосиловых параметров\n");

            temporaryValues2[9] = 1 - temporaryValues2[0] / inputData2[0];
            res = new Result("epsilon", "Средняя степень деформации", "–", Math.Round(temporaryValues2[9], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[10] = 0.105 * inputData2[5] * Math.Sqrt(temporaryValues2[9] * inputData2[3] / inputData2[0]);
            res = new Result("Uc", "Средняя скорость деформации", "–", Math.Round(temporaryValues2[10], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[11] = Math.Log(inputData2[0] / temporaryValues2[0]);
            res = new Result("epsilon_l", "Конечная логарифмическая степень деформации", "–", Math.Round(temporaryValues2[11], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[12] = inputData2[6] + 14.4 * Math.Pow(temporaryValues2[9], 0.83);
            res = new Result("sigma_sc", "Среднее сопротивление деформации", "МПа", Math.Round(temporaryValues2[12], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[13] = Math.Sqrt((inputData2[0] - temporaryValues2[0]) * inputData2[3]);
            res = new Result("l", "Длина очага деформации", "мм", Math.Round(temporaryValues2[13], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[14] = (inputData2[0] + temporaryValues2[0]) / 2;
            res = new Result("hc", "Средняя высота в очаге деформации", "мм", Math.Round(temporaryValues2[14], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[15] = Math.Pow(temporaryValues2[13] / temporaryValues2[14], -0.42);
            res = new Result("n_sigma", "Коэффициент напряжённого состояния", "–", Math.Round(temporaryValues2[15], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[16] = temporaryValues2[15] * temporaryValues2[12];
            res = new Result("pc", "Среднее удельное давление", "МПа", Math.Round(temporaryValues2[16], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[17] = ((inputData2[1] + temporaryValues2[2]) / 2) * Math.Sqrt((inputData2[0] + temporaryValues2[0]) * inputData2[3]);
            res = new Result("Fr", "Горизонтальная проекция площади контакта полосы с валками", "мм^2", Math.Round(temporaryValues2[17], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[18] = temporaryValues2[17] * temporaryValues2[16] / 1000;
            res = new Result("P", "Усилие прокатки", "кН", Math.Round(temporaryValues2[18], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[19] = temporaryValues2[18] * temporaryValues2[13] / 1000;
            res = new Result("Mв", "Момент на валках", "кН/м", Math.Round(temporaryValues2[19], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[20] = 0.3 * inputData2[6];
            res = new Result("sigma_н", "Удельное натяжение полосы", "МПа", Math.Round(temporaryValues2[20], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[21] = temporaryValues2[20] * inputData2[0] * inputData2[1];
            res = new Result("Tn", "Переднее натяжение полосы", "кН", Math.Round(temporaryValues2[21] / 1000, r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[22] = temporaryValues2[20] * temporaryValues2[0] * temporaryValues2[2];
            res = new Result("Tз", "Заднее натяжение полосы", "кН", Math.Round(temporaryValues2[22] / 1000, r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[23] = temporaryValues1[24];
            res = new Result("V02", "Скорость на входе", "м/с", Math.Round(temporaryValues2[23], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            temporaryValues2[24] = temporaryValues2[23] * temporaryValues2[5];
            res = new Result("V12", "Скорость на выходе", "м/с", Math.Round(temporaryValues2[24], r));
            results.Add(res);
            Console.WriteLine($"{res.name} | {res.mark} | {res.ci} | {res.value}");

            for (int i = 25; i < 50; i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i - 25].Cells[0].Value = results[i].name + " | " + results[i].mark + " | " + results[i].ci;
                dataGridView2.Rows[i - 25].Cells[1].Value = results[i].value;
            }

            double[] dopValues2 = new double[20];

            List<Result> dopResults2 = new List<Result>();

            dopValues2[0] = temporaryValues2[18] * (0.36 - 0.0005 * inputData1[1]) / (3.2 * Math.Pow(10, -6) * Math.Pow(inputData1[3], 3));
            res = new Result("sigma_из.б.", "Максимальные напряжения изгиба в бочке валка", "МПа", Math.Round(dopValues2[0], r));
            dopResults2.Add(res);

            dopValues2[1] = 0.390625 * temporaryValues2[18];
            res = new Result("sigma_из.ш.", "Максимальные изгибающие напряжения в шейке валка", "МПа", Math.Round(dopValues2[1], r));
            dopResults2.Add(res);

            dopValues2[2] = 640 / dopValues2[0];
            res = new Result("nб", "Коэфф запаса прочности в б.в.", "МПа", Math.Round(dopValues2[2], r));
            dopResults2.Add(res);

            dopValues2[3] = 640 / dopValues2[1];
            res = new Result("nш", "Коэфф запаса прочности в ш.в.", "МПа", Math.Round(dopValues2[3], r));
            dopResults2.Add(res);

            dopValues2[4] = 0.2275 * temporaryValues2[18];
            res = new Result("sigma_см.г.", "Напр смятия на поверхности соприкосновения гайки", "МПа", Math.Round(dopValues2[4], r));
            dopResults2.Add(res);

            dopValues2[5] = 0.0357 * temporaryValues2[18];
            res = new Result("sigma_см.", "Напряжение смятия резьбы гайки", "МПа", Math.Round(dopValues2[5], r));
            dopResults2.Add(res);

            dopValues2[6] = 0.2958 * temporaryValues2[18];
            res = new Result("sigma_из.", "Напряжение смятия резьбы гайки", "МПа", Math.Round(dopValues2[6], r));
            dopResults2.Add(res);

            dopValues2[7] = 400 / dopValues2[4];
            res = new Result("nсм.г.", "Коэфф запаса прочности для поверхности соприкосновения гайки с поперечиной станины",
                "МПа", Math.Round(dopValues2[7], r));
            dopResults2.Add(res);

            dopValues2[8] = 400 / dopValues2[5];
            res = new Result("nсм.", "Коэфф запаса прочности для резьбы гайки по напряжениям смятия",
                "МПа", Math.Round(dopValues2[8], r));
            dopResults2.Add(res);

            dopValues2[9] = 400 / dopValues2[6];
            res = new Result("nиз.", "Коэфф запаса прочности для резьбы гайки по напряжениям изгиба",
                "МПа", Math.Round(dopValues2[9], r));
            dopResults2.Add(res);

            dopValues2[10] = (0.046 * temporaryValues2[18] - 0.2) / 1.8;
            res = new Result("sigma_1", "Напряжение в нижней поперечине",
                "МПа", Math.Round(dopValues2[10], r));
            dopResults2.Add(res);

            dopValues2[11] = (temporaryValues2[18] / 48) + 1.17;
            res = new Result("sigma_2", "Напряжение в стойках",
                "МПа", Math.Round(dopValues2[11], r));
            dopResults2.Add(res);

            dopValues2[12] = (0.046 * temporaryValues2[18] - 0.2) / 18;
            res = new Result("sigma_3", "Напряжение в верхней поперечине",
                "МПа", Math.Round(dopValues2[12], r));
            dopResults2.Add(res);

            dopValues2[13] = 600 / dopValues2[10];
            res = new Result("n1", "Коэфф запаса прочности для нижней поперечины",
                "-", Math.Round(dopValues2[13], r));
            dopResults2.Add(res);

            dopValues2[14] = 600 / dopValues2[11];
            res = new Result("n2", "Коэфф запаса прочности для стойки",
                "-", Math.Round(dopValues2[14], r));
            dopResults2.Add(res);

            dopValues2[15] = 600 / dopValues2[12];
            res = new Result("n3", "Коэфф запаса прочности для верхней поперечины",
                "-", Math.Round(dopValues2[15], r));
            dopResults2.Add(res);

            for (int i = 25; i < 41; i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = dopResults2[i - 25].name + " | " + dopResults2[i - 25].mark + " | " + dopResults2[i - 25].ci;
                dataGridView2.Rows[i].Cells[1].Value = dopResults2[i - 25].value;
            }

            List<string> argsToPictureStr = new List<string>();

            double Mm1 = inputData1[6] * (inputData1[0] * inputData1[0] * inputData1[1] / 4 + 0.045 * inputData1[0] * inputData1[1]);
            double Mm2 = inputData1[6] * (temporaryValues2[0] * temporaryValues2[0] * temporaryValues2[2] / 4 + 0.045 * temporaryValues2[0] * temporaryValues2[2]);



            argsToPictureStr.Add("Tп= " + Math.Round(temporaryValues1[21]/1000, r).ToString() + " кН");
            argsToPictureStr.Add("V01= " + Math.Round(temporaryValues1[23], r).ToString() + " м/с");

            argsToPictureStr.Add("P= " + Math.Round(temporaryValues1[18], r).ToString() + " кН");
            argsToPictureStr.Add("Мм1= " + Math.Round(Mm1/1000, r).ToString() + " кН*м");

            argsToPictureStr.Add("P=  " + Math.Round(temporaryValues2[18], r).ToString() + " кН");
            argsToPictureStr.Add("Мм2= " + Math.Round(Mm2/1000, r).ToString() + " кН*м");

            argsToPictureStr.Add("Tп= " + Math.Round(temporaryValues2[21]/1000, r).ToString() + " кН");
            argsToPictureStr.Add("V12= " + Math.Round(temporaryValues2[24], r).ToString() + " м/с");

            argsToPictureStr.Add("Мв= " + Math.Round(temporaryValues1[19], r).ToString() + " кН/м");
            argsToPictureStr.Add("Мв= " + Math.Round(temporaryValues2[19], r).ToString() + " кН/м");

            List<double> argsToPictureDouble = new List<double>();

            argsToPictureDouble.Add(dopValues1[2]);
            argsToPictureDouble.Add(dopValues1[3]);
            argsToPictureDouble.Add(dopValues1[7]);
            argsToPictureDouble.Add(dopValues1[8]);
            argsToPictureDouble.Add(dopValues1[9]);

            argsToPictureDouble.Add(Math.Round(temporaryValues1[18], r));

            /*label10.Text = "Tп= " + Math.Round(temporaryValues1[21], r).ToString() + " кН";
            label9.Text = "V01= " + Math.Round(temporaryValues1[23], r).ToString() + " м/с";

            label6.Text = "P= " + Math.Round(temporaryValues1[18], r).ToString() + " кН";
            label7.Text = "Мпр= " + Math.Round(temporaryValues1[21], r).ToString() + " кН*м";

            label12.Text = "P=  " + Math.Round(temporaryValues2[18], r).ToString() + " кН";
            label11.Text = "Мпр= " + Math.Round(temporaryValues2[21], r).ToString() + " кН*м";

            label14.Text = "Tп= " + Math.Round(temporaryValues2[21], r).ToString() + " кН";
            label13.Text = "V12= " + Math.Round(temporaryValues2[24], r).ToString() + " м/с";*/

            /*pictureBox1.Load("4(1).jpg");

            if (dopValues1[2] < 5 && dopValues1[3] < 5)
            {
                pictureBox1.Load("1(1).jpg");
            }
            if (dopValues1[7] < 5 && dopValues1[8] < 5 && dopValues1[9] < 5)
            {
                pictureBox1.Load("2(1).jpg");
            }
            if (dopValues1[2] < 5 && dopValues1[3] < 5 && dopValues1[7] < 5 && dopValues1[8] < 5 && dopValues1[9] < 5)
            {
                pictureBox1.Load("3(1).jpg");
            }
            if (dopValues1[2] >= 5 && dopValues1[3] >= 5 && dopValues1[7] >= 5 && dopValues1[8] >= 5 && dopValues1[9] >= 5)
            {
                pictureBox1.Load("4(1).jpg");
            }*/

            PictureResult newFormPicture = new PictureResult(argsToPictureDouble, argsToPictureStr);
            newFormPicture.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
