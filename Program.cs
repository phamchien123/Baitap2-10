using System;
// Abstract class Product
public abstract class Product
{
    public string Name { get; set; }
    public decimal  Price { get; set; }
    public int Stock { get; set; }
    public void Nhapthongtin()
    {
        Console.Write("Nhap ten san pham: ");
        Name = Console.ReadLine();
        Console.Write("Nhap gia: ");
        Price = decimal.Parse(Console.ReadLine());
        Console.Write("Nhap so luong ton kho: ");
        Stock = int.Parse(Console.ReadLine());
    }
    public virtual void Hienthi()
    {
        Console.WriteLine("Ten san pham: " + Name);
        Console.WriteLine("Gia san pham: " + Price);
        Console.WriteLine("So luong ton kho: " + Stock);
    }
    public abstract void Giamgia(decimal percentage);
}
public interface ISellable
{
    void Sell(int quantity);
    bool IsInStock();
}
public class MobilePhone : Product, ISellable
{
    public void Nhapmagiamgia()
    {
        Console.WriteLine("Nhap ma giam gia: ");
        
    }
    public override void Giamgia(decimal percentage)
    {
        decimal discountAmount = Price * (percentage / 100);
        Price -= discountAmount;
        Console.WriteLine("Gia sau khi giam cua dien thoai: " + Price);
    }

    public override void Hienthi()
    {
        Console.WriteLine("San pham: Mobile Phone");
        base.Hienthi();
    }

    public void Sell(int quantity)
    {
        if (quantity > Stock)
        {
            Console.WriteLine("Khong du hang trong kho de ban.");
        }
        else
        {
            Stock -= quantity;
            Console.WriteLine(quantity + " dien thoai da duoc ban. So luong ton kho con lai: " + Stock);
        }
    }

    public bool IsInStock()
    {
        return Stock > 0;
    }
}
public class Laptop : Product, ISellable
{
    public override void Giamgia(decimal percentage)
    {
        decimal discountAmount = Price * (percentage / 100);
        Price -= discountAmount;
        Console.WriteLine("Gia sau khi giam cua laptop: " + Price);
    }

    public override void Hienthi()
    {
        Console.WriteLine("San pham: Laptop");
        base.Hienthi();
    }

    public void Sell(int quantity)
    {
        if (quantity > Stock)
        {
            Console.WriteLine("Khong du hang trong kho de ban.");
        }
        else
        {
            Stock -= quantity;
            Console.WriteLine(quantity + " laptop da duoc ban. So luong ton kho con lai: " + Stock);
        }
    }

    public bool IsInStock()
    {
        return Stock > 0;
    }
}
public class Accessory : Product, ISellable
{
    public override void Giamgia(decimal percentage)
    {
        decimal discountAmount = Price * (percentage / 100);
        Price -= discountAmount;
        Console.WriteLine("Gia sau khi giam cua phu kien: " + Price);
    }

    public override void Hienthi()
    {
        Console.WriteLine("San pham: Phu Kien");
        base.Hienthi();
    }

    public void Sell(int quantity)
    {
        if (quantity > Stock)
        {
            Console.WriteLine("Khong du hang trong kho de ban.");
        }
        else
        {
            Stock -= quantity;
            Console.WriteLine(quantity + " phu kien da duoc ban. So luong ton kho con lai: " + Stock);
        }
    }
    public bool IsInStock()
    {
        return Stock > 0;
    }
}
class Program
{
    static void Main()
    {
        MobilePhone phone = new MobilePhone();
        Laptop laptop = new Laptop();
        Accessory accessory = new Accessory();

        Console.WriteLine("Nhap thong tin cho dien thoai:");
        phone.Nhapthongtin();

        Console.WriteLine("\nNhap thong tin cho laptop:");
        laptop.Nhapthongtin();

        Console.WriteLine("\nNhap thong tin cho phu kien:");
        accessory.Nhapthongtin();

        
        Console.WriteLine("Thong tin san pham:");
        phone.Hienthi();
        laptop.Hienthi();
        accessory.Hienthi();

        Console.Write("Nhap ma giam gia: ");
        int x = int.Parse(Console.ReadLine());
        Console.WriteLine("\nAp dung giam gia:");
        phone.Giamgia(x);
        laptop.Giamgia(x);
        accessory.Giamgia(x);

        Console.Write("Nhap so luong ban: ");
        int y = int.Parse(Console.ReadLine());
        int z = int.Parse(Console.ReadLine());
        int i = int.Parse(Console.ReadLine());
        Console.WriteLine("\nBan san pham:");
        phone.Sell(y);
        laptop.Sell(z);
        accessory.Sell(i);

        Console.WriteLine("\nKiem tra ton kho:");
        Console.WriteLine("Dien thoai con trong kho: " + phone.IsInStock());
        Console.WriteLine("Laptop con trong kho: " + laptop.IsInStock());
        Console.WriteLine("Phu kien con trong kho: " + accessory.IsInStock());
    }
}
