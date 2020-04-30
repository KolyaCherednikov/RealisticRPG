using System;
using System.Collections.Generic;
using System.Text;

// Клас который содержит типы вещей для крафта
public class ItemTypes{
    public static Item CreateBadSword() // Создать плохой меч
    {
        Item sw = new Item("Bad Sword", 5, 1, 15);
        return sw;
    }
    public static Item CreateMediumSword() // Создать обычный меч
    {
        Item sw = new Item("Medium Sword", 10, 2, 25);
        return sw;
    }
    public static Item CreatePerfectSword() // Создать идеальный меч
    {
        Item sw = new Item("Perfect Sword", 15, 3, 35);
        return sw;
    }
}
