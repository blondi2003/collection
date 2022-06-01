using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

var path = "table.csv";

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
Encoding encoding = Encoding.GetEncoding(1251);

var lines = File.ReadAllLines(path, encoding);
var cell = new Info[lines.Length - 1];

for (int i = 1; i < lines.Length; i++)
{
    var splits = lines[i].Split(';');
    var content = new Info();
    content.Id = Convert.ToInt32(splits[0]);
    content.Name = splits[1];
    content.Email = splits[2];
    content.Phone = splits[3];
    content.Age = Convert.ToInt32(splits[4]);
    content.City = splits[5];
    content.Street = splits[6];
    content.Tag = splits[7];
    content.Price = Convert.ToInt32(splits[8]);
    content.CustomerId = splits[9];
    content.ProductId = splits[10];

    cell[i - 1] = content;
}

//Задание 1
Console.WriteLine("Задание 1");

int Phone = 0;

if (Phone == cell.Length) Console.WriteLine("Записи по свойству Phone не уникальны");

for (var i = 0; i < cell.Length; i++)
{
    int k = cell.Count(a => a.Phone == cell[i].Phone);
    if (k != Phone)
    {
        Console.WriteLine("Записи по свойству Phone уникальны");
        break;
    }
    Phone++;
}

Console.WriteLine();

//Задание 2
Console.WriteLine("Задание 2");
Console.WriteLine("Заказ с наибольшей ценой: " + cell.Max(x => x.Price));
Console.WriteLine();

//Задание 3
Console.WriteLine("Задание 3");
var sorted = from x in cell
             orderby x.Tag descending
             select x;

var result = "resultsortedetag.csv";

using (StreamWriter streamWriter = new StreamWriter(result, false, encoding))
{
    streamWriter.WriteLine($"Id;Name;Email;Phone;Age;City;Street;Tag;Price;CustomerId;ProductId");

    foreach (var a in sorted)
    {
        streamWriter.WriteLine(a.ToExcel());
    }
    foreach (Info person in sorted)
        Console.WriteLine(person.Id + " " + person.Name + " " + person.Email + " " + person.City + " " + person.Phone + " " + person.Age + " " + person.Street + " " + person.Tag + " " + person.Price + " " + person.CustomerId + " " + person.ProductId + " ");
}
Console.WriteLine();
Console.WriteLine();

//Задание 4
Console.WriteLine("Задание 4");
var selectedtag = from tag in cell
                   where tag.Tag.Contains("Кулон")
                   select tag;
var result1 = "resulttag.csv";
using (StreamWriter streamWriter = new StreamWriter(result1, false, encoding))
{
    streamWriter.WriteLine($"Id;Name;Email;Phone;Age;City;Street;Tag;Price;CustomerId;ProductId");

    foreach (var kulon in selectedtag)
    {
        streamWriter.WriteLine(kulon.ToExcel());
    }
    foreach (Info person in selectedtag)
    Console.WriteLine(person.Id + " " + person.Name + " " + person.Email + " " + person.City + " " + person.Phone + " " + person.Age + " " + person.Street + " " + person.Tag + " " + person.Price + " " + person.CustomerId + " " + person.ProductId + " ");
}
Console.WriteLine();
Console.WriteLine();

//Задание 5
char[] symbols = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'e', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'm', 'N', 'O', 'P', 'Q', 'r', 'S', 'T', 'U', 'v', 'W', 'X', 'Y', 'z' };
string[] emails = { "kaft93x@outlook.com", "wnhborq@outlook.com", "u7yhwf1vb@mail.ru", "d2mc@outlook.com", "78k3dvwx@outlook.com", "8swlo27hd@outlook.com", "3vmtdo1@outlook.com", "dihf8jxk@gmail.com", "5hsbm8pi3@mail.ru" };
string[] names = { "Сапсай Иван", "Миронова Елизавета", "Мощева Алина", "Власова Мария", "Белюга Татьяна", "Буракшаева Юлия", "Мельникова Ксения", "Моругина Ирина", "Химич Елена", "Скалий Юлия", "Кинах Вадим", "Кочеткова Неонила" };
string[] cities = { "Москва", "Париж", "Рим", "Минск", "Киев", "Баку", "Токио", "Сеул", "Вашингтон", "Барселона", "Осло", "Пекин", "Рио-де-Жанейро" };
string[] phones = { "(810)465-59-91", "(918)797-40-85", "(910)637-71-24", "(910)093-64-44", "(808)001-89-22", "(980)809-01-91", "(913)456-72-48", "(930)101-00-60", "(920)335-45-39", "(918)132-43-83", "(945)132-00-83" };
string[] streets = { "Красная улица", "Орчард-роуд", "Невский проспект", "Розовая улица", "Бруверсграхт", "Елисейские поля", "Манхэттен",
"Тверская улица", "Проспект Ленина", "Улица им. Лузана", "Студгородок" };
string[] tags = { "Хайлайтер", "Праймер", "Тональная основа", "Увлажняющий крем", "Тушь", "Кисти", "Блеск для губ", "Глитер", "Румяна", "Спонж", "Карандаш для губ", "Фиксатоор", "Пудра", "Консилер" };
string[] ages = { "35", "27", "37", "33", "22", "18", "93", "49", "40", "20", "36", "79", "19", "88", "90" };
var customId = new List<string>();
var productID = new List<string>();
Random random = new Random();

for (int j = 0; j < 10; j++)
{
    string str = "";
    for (int i = 0; i < 10; i++)
    {
        var newstr = symbols[random.Next(0, symbols.Length)];
        str += newstr;
    }
    customId.Add(str);
}

for (int g = 0; g < 10; g++)
{
    string stri = "";
    for (int o = 0; o < 10; o++)
    {
        var newstri = symbols[random.Next(0, symbols.Length)];
        stri += newstri;
    }
    productID.Add(stri);
}
var result2 = "result.csv";

using (var writer = new StreamWriter(result2, true, encoding))

{

    for (int l = cell.Length + 1; l < cell.Length + 5; l++)
    {
        var NewRecord = new List<Info>()
{
new Info { Id = l, Name = names[random.Next(0, names.Length)], Email = emails[random.Next(0, emails.Length)], Phone = phones[random.Next(0, phones.Length)], Age = random.Next(0, ages.Length), City = cities[random.Next(0, cities.Length)], Street = streets[random.Next(0, streets.Length)], Tag = tags[random.Next(0, tags.Length)], Price = random.Next(200, 40000), CustomerId = customId[random.Next(0, customId.Count)], ProductId = productID[random.Next(0, productID.Count)] }
};
        foreach (var n in NewRecord)
        {
            writer.WriteLine(n.ToExcel());
        }
    }
}




public class Info
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Tag { get; set; }
    public int Price { get; set; }
    public string CustomerId { get; set; }
    public string ProductId { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}\n Имя и фамилия: {Name}\n Электронный адрес : {Email}\n Номер телефона: {Phone}\n Возраст: {Age}\n Город: {City}\n Улица: {Street}\n Тэг:{Tag}\n Цена: {Price}\n Id покупателя: {CustomerId}\n Id товара: {ProductId}\n ";
    }
    public string ToExcel()
    {
        return $"{Id};{Name};{Email};{Phone};{Age};{City};{Street};{Tag};{Price};{CustomerId};{ProductId}";
    }
}