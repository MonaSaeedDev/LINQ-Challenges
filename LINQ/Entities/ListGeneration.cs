using LINQ.Enums;

namespace LINQ.Entities;


internal static class ListGenerator
{
    public static List<Product> ProductList { get; } =
    [
        new Product { Id = 1, Name = "Laptop Pro 15", Category = "Electronics", UnitPrice = 1299.99m, UnitsInStock = 45 },
        new Product { Id = 2, Name = "Wireless Mouse", Category = "Electronics", UnitPrice = 29.99m, UnitsInStock = 150 },
        new Product { Id = 3, Name = "Office Chair Deluxe", Category = "Furniture", UnitPrice = 349.99m, UnitsInStock = 30 },
        new Product { Id = 4, Name = "USB-C Cable", Category = "Electronics", UnitPrice = 12.99m, UnitsInStock = 200 },
        new Product { Id = 5, Name = "Standing Desk", Category = "Furniture", UnitPrice = 599.99m, UnitsInStock = 20 },
        new Product { Id = 6, Name = "Mechanical Keyboard", Category = "Electronics", UnitPrice = 89.99m, UnitsInStock = 75 },
        new Product { Id = 7, Name = "Coffee Maker Premium", Category = "Appliances", UnitPrice = 149.99m, UnitsInStock = 40 },
        new Product { Id = 8, Name = "Water Bottle Insulated", Category = "Kitchen", UnitPrice = 24.99m, UnitsInStock = 120 },
        new Product { Id = 9, Name = "Notebook Set", Category = "Stationery", UnitPrice = 15.99m, UnitsInStock = 180 },
        new Product { Id = 10, Name = "Desk Lamp LED", Category = "Furniture", UnitPrice = 39.99m, UnitsInStock = 90 },
        new Product { Id = 11, Name = "Smartphone X12", Category = "Electronics", UnitPrice = 899.99m, UnitsInStock = 55 },
        new Product { Id = 12, Name = "Wireless Headphones", Category = "Electronics", UnitPrice = 179.99m, UnitsInStock = 65 },
        new Product { Id = 13, Name = "Tablet 10 inch", Category = "Electronics", UnitPrice = 449.99m, UnitsInStock = 38 },
        new Product { Id = 14, Name = "Monitor 27 inch 4K", Category = "Electronics", UnitPrice = 499.99m, UnitsInStock = 42 },
        new Product { Id = 15, Name = "Backpack Professional", Category = "Accessories", UnitPrice = 79.99m, UnitsInStock = 85 },
        new Product { Id = 16, Name = "Printer Laser Color", Category = "Electronics", UnitPrice = 329.99m, UnitsInStock = 25 },
        new Product { Id = 17, Name = "External SSD 1TB", Category = "Electronics", UnitPrice = 129.99m, UnitsInStock = 95 },
        new Product { Id = 18, Name = "Webcam HD 1080p", Category = "Electronics", UnitPrice = 69.99m, UnitsInStock = 110 },
        new Product { Id = 19, Name = "Desk Organizer", Category = "Stationery", UnitPrice = 19.99m, UnitsInStock = 140 },
        new Product { Id = 20, Name = "Ergonomic Mouse Pad", Category = "Accessories", UnitPrice = 14.99m, UnitsInStock = 175 },
        new Product { Id = 21, Name = "Smart Watch Series 5", Category = "Electronics", UnitPrice = 299.99m, UnitsInStock = 48 },
        new Product { Id = 22, Name = "Portable Charger 20000mAh", Category = "Electronics", UnitPrice = 49.99m, UnitsInStock = 130 },
        new Product { Id = 23, Name = "Bluetooth Speaker", Category = "Electronics", UnitPrice = 59.99m, UnitsInStock = 88 },
        new Product { Id = 24, Name = "Filing Cabinet 4 Drawer", Category = "Furniture", UnitPrice = 249.99m, UnitsInStock = 18 },
        new Product { Id = 25, Name = "Whiteboard 48x36", Category = "Office", UnitPrice = 89.99m, UnitsInStock = 35 },
        new Product { Id = 26, Name = "Paper Shredder", Category = "Office", UnitPrice = 119.99m, UnitsInStock = 28 },
        new Product { Id = 27, Name = "Bookshelf 5 Tier", Category = "Furniture", UnitPrice = 159.99m, UnitsInStock = 32 },
        new Product { Id = 28, Name = "Desk Fan Oscillating", Category = "Appliances", UnitPrice = 34.99m, UnitsInStock = 72 },
        new Product { Id = 29, Name = "Calculator Scientific", Category = "Office", UnitPrice = 22.99m, UnitsInStock = 105 },
        new Product { Id = 30, Name = "Stapler Heavy Duty", Category = "Stationery", UnitPrice = 18.99m, UnitsInStock = 160 },
        new Product { Id = 31, Name = "Router WiFi 6", Category = "Electronics", UnitPrice = 179.99m, UnitsInStock = 52 },
        new Product { Id = 32, Name = "Power Strip Surge Protector", Category = "Electronics", UnitPrice = 29.99m, UnitsInStock = 145 },
        new Product { Id = 33, Name = "Laptop Stand Adjustable", Category = "Accessories", UnitPrice = 44.99m, UnitsInStock = 98 },
        new Product { Id = 34, Name = "Document Scanner", Category = "Office", UnitPrice = 199.99m, UnitsInStock = 22 },
        new Product { Id = 35, Name = "Pen Set Executive", Category = "Stationery", UnitPrice = 39.99m, UnitsInStock = 115 },
        new Product { Id = 36, Name = "Label Maker", Category = "Office", UnitPrice = 54.99m, UnitsInStock = 68 },
        new Product { Id = 37, Name = "Floor Mat Anti-Fatigue", Category = "Furniture", UnitPrice = 64.99m, UnitsInStock = 58 },
        new Product { Id = 38, Name = "USB Hub 7 Port", Category = "Electronics", UnitPrice = 34.99m, UnitsInStock = 125 },
        new Product { Id = 39, Name = "Scissors Premium", Category = "Stationery", UnitPrice = 12.99m, UnitsInStock = 190 },
        new Product { Id = 40, Name = "Folder Set 100 Pack", Category = "Stationery", UnitPrice = 24.99m, UnitsInStock = 155 },
        new Product { Id = 41, Name = "Hole Punch 3 Hole", Category = "Office", UnitPrice = 16.99m, UnitsInStock = 142 },
        new Product { Id = 42, Name = "Binder Set 12 Pack", Category = "Stationery", UnitPrice = 32.99m, UnitsInStock = 108 },
        new Product { Id = 43, Name = "Tape Dispenser Desktop", Category = "Office", UnitPrice = 9.99m, UnitsInStock = 185 },
        new Product { Id = 44, Name = "Clipboard Aluminum", Category = "Office", UnitPrice = 14.99m, UnitsInStock = 135 },
        new Product { Id = 45, Name = "Calendar Desk Planner", Category = "Stationery", UnitPrice = 18.99m, UnitsInStock = 122 },
        new Product { Id = 46, Name = "Marker Set 24 Colors", Category = "Stationery", UnitPrice = 21.99m, UnitsInStock = 148 },
        new Product { Id = 47, Name = "Sticky Notes Collection", Category = "Stationery", UnitPrice = 11.99m, UnitsInStock = 210 },
        new Product { Id = 48, Name = "Bulletin Board Cork", Category = "Office", UnitPrice = 27.99m, UnitsInStock = 78 },
        new Product { Id = 49, Name = "Magnifying Glass LED", Category = "Office", UnitPrice = 29.99m, UnitsInStock = 82 },
        new Product { Id = 50, Name = "Letter Tray Stackable", Category = "Office", UnitPrice = 19.99m, UnitsInStock = 165 }
    ];

    public static List<Order> OrderList { get; } =
[
    new Order(1001, new DateTime(2024, 1, 15), 1299.99m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 1), // Laptop Pro 15
            ProductList.First(p => p.Id == 2)  // Wireless Mouse
        ]
    },
    new Order(1002, new DateTime(2024, 1, 20), 459.97m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 3), // Office Chair Deluxe
            ProductList.First(p => p.Id == 4), // USB-C Cable
            ProductList.First(p => p.Id == 6)  // Mechanical Keyboard
        ]
    },
    new Order(1003, new DateTime(2024, 2, 3), 89.99m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 6)  // Mechanical Keyboard
        ]
    },
    new Order(1004, new DateTime(2024, 2, 10), 749.98m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 5), // Standing Desk
            ProductList.First(p => p.Id == 10) // Desk Lamp LED
        ]
    },
    new Order(1005, new DateTime(2024, 2, 14), 179.99m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 12) // Wireless Headphones
        ]
    },
    new Order(1006, new DateTime(2024, 3, 1), 599.99m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 5)  // Standing Desk
        ]
    },
    new Order(1007, new DateTime(2024, 3, 8), 249.95m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 8), // Water Bottle
            ProductList.First(p => p.Id == 9), // Notebook Set
            ProductList.First(p => p.Id == 15) // Backpack Professional
        ]
    },
    new Order(1008, new DateTime(2024, 3, 15), 1899.98m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 11), // Smartphone X12
            ProductList.First(p => p.Id == 14), // Monitor 27 inch 4K
            ProductList.First(p => p.Id == 17)  // External SSD 1TB
        ]
    },
    new Order(1009, new DateTime(2024, 3, 22), 129.99m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 17)  // External SSD 1TB
        ]
    },
    new Order(1010, new DateTime(2024, 4, 5), 329.99m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 16) // Printer Laser Color
        ]
    },
    new Order(1011, new DateTime(2024, 4, 12), 899.99m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 11) // Smartphone X12
        ]
    },
    new Order(1012, new DateTime(2024, 4, 18), 449.99m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 13) // Tablet 10 inch
        ]
    },
    new Order(1013, new DateTime(2024, 5, 2), 199.98m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 20), // Ergonomic Mouse Pad
            ProductList.First(p => p.Id == 23)  // Bluetooth Speaker
        ]
    },
    new Order(1014, new DateTime(2024, 5, 9), 499.99m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 14) // Monitor 27 inch 4K
        ]
    },
    new Order(1015, new DateTime(2024, 5, 16), 79.99m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 15) // Backpack Professional
        ]
    },
    new Order(1016, new DateTime(2024, 5, 23), 689.96m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 3),  // Office Chair Deluxe
            ProductList.First(p => p.Id == 5),  // Standing Desk
            ProductList.First(p => p.Id == 37)  // Floor Mat Anti-Fatigue
        ]
    },
    new Order(1017, new DateTime(2024, 6, 1), 299.99m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 21) // Smart Watch Series 5
        ]
    },
    new Order(1018, new DateTime(2024, 6, 8), 549.98m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 12), // Wireless Headphones
            ProductList.First(p => p.Id == 23)  // Bluetooth Speaker
        ]
    },
    new Order(1019, new DateTime(2024, 6, 15), 149.99m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 7) // Coffee Maker Premium
        ]
    },
    new Order(1020, new DateTime(2024, 6, 22), 1199.97m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 1), // Laptop Pro 15
            ProductList.First(p => p.Id == 22) // Portable Charger 20000mAh
        ]
    },
    new Order(1021, new DateTime(2024, 7, 3), 379.98m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 10), // Desk Lamp LED
            ProductList.First(p => p.Id == 25)  // Whiteboard 48x36
        ]
    },
    new Order(1022, new DateTime(2024, 7, 10), 89.99m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 6) // Mechanical Keyboard
        ]
    },
    new Order(1023, new DateTime(2024, 7, 17), 259.97m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 33), // Laptop Stand Adjustable
            ProductList.First(p => p.Id == 20)  // Ergonomic Mouse Pad
        ]
    },
    new Order(1024, new DateTime(2024, 7, 24), 899.99m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 11) // Smartphone X12
        ]
    },
    new Order(1025, new DateTime(2024, 8, 2), 179.99m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 12) // Wireless Headphones
        ]
    },
    new Order(1026, new DateTime(2024, 8, 9), 649.97m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 3),  // Office Chair Deluxe
            ProductList.First(p => p.Id == 16)  // Printer Laser Color
        ]
    },
    new Order(1027, new DateTime(2024, 8, 16), 299.99m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 21) // Smart Watch Series 5
        ]
    },
    new Order(1028, new DateTime(2024, 8, 23), 1549.98m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 1), // Laptop Pro 15
            ProductList.First(p => p.Id == 14) // Monitor 27 inch 4K
        ]
    },
    new Order(1029, new DateTime(2024, 9, 1), 449.99m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 13) // Tablet 10 inch
        ]
    },
    new Order(1030, new DateTime(2024, 9, 8), 199.98m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 18), // Webcam HD 1080p
            ProductList.First(p => p.Id == 23)  // Bluetooth Speaker
        ]
    },
    new Order(1031, new DateTime(2024, 9, 15), 799.98m)
    {
        Products =
        [
            ProductList.First(p => p.Id == 3), // Office Chair Deluxe
            ProductList.First(p => p.Id == 5)  // Standing Desk
        ]
    }
];


    public static List<Customer> CustomerList { get; } =
    [
        new Customer { Id = "ALFKI", Name = "Alfreds Futterkiste", City = "Berlin", Country = "Germany", Phone = "030-0074321", Orders = [new Order(1001, new DateTime(2024,1,15),1299.99m), new Order(1002,new DateTime(2024,1,20),459.97m)] },
    new Customer { Id = "ANATR", Name = "Ana Trujillo Emparedados", City = "México D.F.", Country = "Mexico", Phone = "(5) 555-4729", Orders = [new Order(1003,new DateTime(2024,2,3),89.99m), new Order(1004,new DateTime(2024,2,10),749.98m)] },
    new Customer { Id = "ANTON", Name = "Antonio Moreno Taquería", City = "México D.F.", Country = "Mexico", Phone = "(5) 555-3932", Orders = [new Order(1005,new DateTime(2024,2,14),179.99m)] },
    new Customer { Id = "AROUT", Name = "Around the Horn", City = "London", Country = "UK", Phone = "(171) 555-7788", Orders = [new Order(1006,new DateTime(2024,3,1),599.99m)] },
    new Customer { Id = "BERGS", Name = "Berglunds snabbköp", City = "Luleå", Country = "Sweden", Phone = "0921-12 34 65", Orders = [new Order(1007,new DateTime(2024,3,8),249.95m)] },
    new Customer { Id = "BLAUS", Name = "Blauer See Delikatessen", City = "Mannheim", Country = "Germany", Phone = "0621-08460", Orders = [new Order(1008,new DateTime(2024,3,15),1899.98m)] },
    new Customer { Id = "BLONP", Name = "Blondel père et fils", City = "Strasbourg", Country = "France", Phone = "88.60.15.31", Orders = [new Order(1009,new DateTime(2024,3,22),129.99m)] },
    new Customer { Id = "BOLID", Name = "Bólido Comidas preparadas", City = "Madrid", Country = "Spain", Phone = "(91) 555 22 82", Orders = [new Order(1010,new DateTime(2024,4,5),329.99m)] },
    new Customer { Id = "BONAP", Name = "Bon app'", City = "Marseille", Country = "France", Phone = "91.24.45.40", Orders = [new Order(1011,new DateTime(2024,4,12),899.99m)] },
    new Customer { Id = "BOTTM", Name = "Bottom-Dollar Markets", City = "Tsawassen", Country = "Canada", Phone = "(604) 555-4729", Orders = [new Order(1012,new DateTime(2024,4,18),449.99m), new Order(1013,new DateTime(2024,5,2),199.98m)] },
    new Customer { Id = "BSBEV", Name = "B's Beverages", City = "London", Country = "UK", Phone = "(171) 555-1212", Orders = new[] { new Order(1014,new DateTime(2024,5,9),499.99m) } },
    new Customer { Id = "CACTU", Name = "Cactus Comidas para llevar", City = "Buenos Aires", Country = "Argentina", Phone = "(1) 135-5555", Orders = new[] { new Order(1015,new DateTime(2024,5,16),79.99m) } },
    new Customer { Id = "CENTC", Name = "Centro comercial Moctezuma", City = "México D.F.", Country = "Mexico", Phone = "(5) 555-3392", Orders = new[] { new Order(1016,new DateTime(2024,5,23),689.96m) } },
    new Customer { Id = "CHOPS", Name = "Chop-suey Chinese", City = "Bern", Country = "Switzerland", Phone = "0452-076545", Orders = new[] { new Order(1017,new DateTime(2024,6,1),299.99m) } },
    new Customer { Id = "COMMI", Name = "Comércio Mineiro", City = "São Paulo", Country = "Brazil", Phone = "(11) 555-7647", Orders = new[] { new Order(1018,new DateTime(2024,6,8),549.98m) } },
    new Customer { Id = "CONSH", Name = "Consolidated Holdings", City = "London", Country = "UK", Phone = "(171) 555-2282", Orders = new[] { new Order(1019,new DateTime(2024,6,15),149.99m), new Order(1020,new DateTime(2024,6,22),1199.97m) } },
    new Customer { Id = "DRACD", Name = "Drachenblut Delikatessen", City = "Aachen", Country = "Germany", Phone = "0241-039123", Orders = new[] { new Order(1021,new DateTime(2024,7,3),379.98m) } },
    new Customer { Id = "DUMON", Name = "Du monde entier", City = "Nantes", Country = "France", Phone = "40.67.88.88", Orders = new[] { new Order(1022,new DateTime(2024,7,10),89.99m) } },
    new Customer { Id = "EASTC", Name = "Eastern Connection", City = "London", Country = "UK", Phone = "(171) 555-0297", Orders = new[] { new Order(1023,new DateTime(2024,7,17),259.97m) } },
    new Customer { Id = "ERNSH", Name = "Ernst Handel", City = "Graz", Country = "Austria", Phone = "7675-3425", Orders = new[] { new Order(1024,new DateTime(2024,7,24),899.99m) } },
    new Customer { Id = "FAMIA", Name = "Familia Arquibaldo", City = "São Paulo", Country = "Brazil", Phone = "(11) 555-9857", Orders = new[] { new Order(1025,new DateTime(2024,8,2),179.99m) } },
    new Customer { Id = "FISSA", Name = "FISSA Fabrica Salchichas", City = "Madrid", Country = "Spain", Phone = "(91) 555 94 44", Orders = new[] { new Order(1026,new DateTime(2024,8,9),649.97m) } },
    new Customer { Id = "FOLIG", Name = "Folies gourmandes", City = "Lille", Country = "France", Phone = "20.16.10.16", Orders = new[] { new Order(1027,new DateTime(2024,8,16),299.99m) } },
    new Customer { Id = "FOLKO", Name = "Folk och fä HB", City = "Bräcke", Country = "Sweden", Phone = "0695-34 67 21", Orders = new[] { new Order(1028,new DateTime(2024,8,23),1549.98m) } },
    new Customer { Id = "FRANK", Name = "Frankenversand", City = "München", Country = "Germany", Phone = "089-0877310", Orders = new[] { new Order(1029,new DateTime(2024,9,1),449.99m) } },
    new Customer { Id = "FRANR", Name = "France restauration", City = "Nantes", Country = "France", Phone = "40.32.21.21", Orders = new[] { new Order(1030,new DateTime(2024,9,8),199.98m) } },
    new Customer { Id = "FRANS", Name = "Franchi S.p.A.", City = "Torino", Country = "Italy", Phone = "011-4988260", Orders = new[] { new Order(1031,new DateTime(2024,9,15),799.98m) } },
    new Customer { Id = "FURIB", Name = "Furia Bacalhau e Frutos do Mar", City = "Lisboa", Country = "Portugal", Phone = "(1) 354-2534", Orders = new[] { new Order(1032,new DateTime(2024,9,22),129.99m) } },
    new Customer { Id = "GALED", Name = "Galería del gastrónomo", City = "Barcelona", Country = "Spain", Phone = "(93) 203 4560", Orders = new[] { new Order(1033,new DateTime(2024,10,1),349.99m) } },
    new Customer { Id = "GODOS", Name = "Godos Cocina Típica", City = "Sevilla", Country = "Spain", Phone = "(95) 555 82 82", Orders = new[] { new Order(1034,new DateTime(2024,10,8),599.99m) } },
    new Customer { Id = "GOURL", Name = "Gourmet Lanchonetes", City = "Campinas", Country = "Brazil", Phone = "(19) 555-7123", Orders = new[] { new Order(1035,new DateTime(2024,10,15),249.97m) } },
    new Customer { Id = "GREAL", Name = "Great Lakes Food Market", City = "Eugene", Country = "USA", Phone = "(503) 555-7555", Orders = new[] { new Order(1036,new DateTime(2024,10,22),1099.98m) } },
    new Customer { Id = "GROSR", Name = "GROSELLA-Restaurante", City = "Caracas", Country = "Venezuela", Phone = "(2) 283-2951", Orders = new[] { new Order(1037,new DateTime(2024,11,2),179.99m) } },
    new Customer { Id = "HANAR", Name = "Hanari Carnes", City = "Rio de Janeiro", Country = "Brazil", Phone = "(21) 555-0091", Orders = new[] { new Order(1038,new DateTime(2024,11,9),499.99m) } },
    new Customer { Id = "HILAA", Name = "HILARION-Abastos", City = "San Cristóbal", Country = "Venezuela", Phone = "(5) 555-1340", Orders = new[] { new Order(1039,new DateTime(2024,11,16),89.99m) } },
    new Customer { Id = "HUNGO", Name = "Hungry Owl All-Night Grocers", City = "Cork", Country = "Ireland", Phone = "2967 542", Orders = new[] { new Order(1040,new DateTime(2024,11,23),749.97m) } },
    new Customer { Id = "ISLAT", Name = "Island Trading", City = "Cowes", Country = "UK", Phone = "(198) 555-8888", Orders = new[] { new Order(1041,new DateTime(2024,12,1),299.99m) } },
    new Customer { Id = "KOENE", Name = "Königlich Essen", City = "Brandenburg", Country = "Germany", Phone = "0555-09876", Orders = [new Order(1042,new DateTime(2024,12,8),1299.99m)] },
    new Customer { Id = "LACOR", Name = "La corne d'abondance", City = "Versailles", Country = "France", Phone = "30.59.84.10", Orders = [new Order(1043,new DateTime(2024,12,15),449.98m)] },
    new Customer { Id = "LAMAI", Name = "La maison d'Asie", City = "Toulouse", Country = "France", Phone = "61.77.61.10", Orders = [new Order(1044,new DateTime(2024,12,22),199.99m)] },
    new Customer { Id = "LAUGB", Name = "Laughing Bacchus Wine Cellars", City = "Vancouver", Country = "Canada", Phone = "(604) 555-3392", Orders = new[] { new Order(1045,new DateTime(2025,1,5),899.99m) } },
    new Customer { Id = "LAZYK", Name = "Lazy K Kountry Store", City = "Walla Walla", Country = "USA", Phone = "(509) 555-7969", Orders = [new Order(1046,new DateTime(2025,1,12),349.97m)] },
    new Customer { Id = "LEHMS", Name = "Lehmanns Marktstand", City = "Frankfurt", Country = "Germany", Phone = "069-0245984", Orders = [new Order(1047,new DateTime(2025,1,19),599.99m)] },
    new Customer { Id = "LETSS", Name = "Let's Stop N Shop", City = "San Francisco", Country = "USA", Phone = "(415) 555-5938", Orders = [new Order(1048,new DateTime(2025,2,2),179.99m)] },
    new Customer { Id = "LILAS", Name = "LILA-Supermercado", City = "Caracas", Country = "Venezuela", Phone = "(2) 555-1948", Orders = [new Order(1049,new DateTime(2025,2,9),1549.97m)] },
    new Customer { Id = "LINOD", Name = "LINO-Delicateses", City = "I. de Margarita", Country = "Venezuela", Phone = "(8) 34-56-12", Orders = [new Order(1050,new DateTime(2025,2,16),249.99m)] },

    // 🟡 Customers with NO orders (for testing)
    new Customer { Id = "MAGAA", Name = "Magazzini Alimentari Riuniti", City = "Bergamo", Country = "Italy", Phone = "035-640230" },
    new Customer { Id = "MAISD", Name = "Maison Dewey", City = "Bruxelles", Country = "Belgium", Phone = "02.201.24.67" },
    new Customer { Id = "MEREP", Name = "Mère Paillarde", City = "Montréal", Country = "Canada", Phone = "(514) 555-8054" },
    new Customer { Id = "OCEAN", Name = "Océano Atlántico Ltda.", City = "Buenos Aires", Country = "Argentina", Phone = "(1) 555-4892" },
    new Customer { Id = "OLDWO", Name = "Old World Delicatessen", City = "Anchorage", Country = "USA", Phone = "(907) 555-7584" }
    ];

    public static List<Employee> EmployeeList { get; } =
    [
        new Employee { Id = 1, Name = "John Smith", Department = Department.IT, Salary = 75000m, YearsOfExperience = 5, IsRemote = true, HireDate = new DateTime(2019, 3, 15), ManagerId = null, IsActive = true },
        new Employee { Id = 2, Name = "Sarah Johnson", Department = Department.HR, Salary = 65000m, YearsOfExperience = 8, IsRemote = false, HireDate = new DateTime(2016, 7, 22), ManagerId = null, IsActive = true },
        new Employee { Id = 3, Name = "Michael Brown", Department = Department.IT, Salary = 82000m, YearsOfExperience = 10, IsRemote = true, HireDate = new DateTime(2014, 1, 10), ManagerId = 1, IsActive = true },
        new Employee { Id = 4, Name = "Emily Davis", Department = Department.Finance, Salary = 70000m, YearsOfExperience = 6, IsRemote = false, HireDate = new DateTime(2018, 5, 8), ManagerId = null, IsActive = true },
        new Employee { Id = 5, Name = "David Wilson", Department = Department.IT, Salary = 68000m, YearsOfExperience = 4, IsRemote = true, HireDate = new DateTime(2020, 9, 1), ManagerId = 1, IsActive = true },
        new Employee { Id = 6, Name = "Lisa Anderson", Department = Department.Marketing, Salary = 72000m, YearsOfExperience = 7, IsRemote = false, HireDate = new DateTime(2017, 11, 15), ManagerId = null, IsActive = true },
        new Employee { Id = 7, Name = "James Taylor", Department = Department.Sales, Salary = 78000m, YearsOfExperience = 9, IsRemote = false, HireDate = new DateTime(2015, 4, 20), ManagerId = null, IsActive = true },
        new Employee { Id = 8, Name = "Jennifer Martinez", Department = Department.IT, Salary = 71000m, YearsOfExperience = 5, IsRemote = true, HireDate = new DateTime(2019, 8, 12), ManagerId = 1, IsActive = false },
        new Employee { Id = 9, Name = "Robert Garcia", Department = Department.Finance, Salary = 85000m, YearsOfExperience = 12, IsRemote = false, HireDate = new DateTime(2012, 2, 28), ManagerId = 4, IsActive = true },
        new Employee { Id = 10, Name = "Maria Rodriguez", Department = Department.HR, Salary = 63000m, YearsOfExperience = 3, IsRemote = false, HireDate = new DateTime(2021, 6, 5), ManagerId = 2, IsActive = true },
        new Employee { Id = 11, Name = "William Lee", Department = Department.Marketing, Salary = 76000m, YearsOfExperience = 8, IsRemote = true, HireDate = new DateTime(2016, 10, 18), ManagerId = 6, IsActive = true },
        new Employee { Id = 12, Name = "Patricia White", Department = Department.Sales, Salary = 69000m, YearsOfExperience = 4, IsRemote = false, HireDate = new DateTime(2020, 3, 25), ManagerId = 7, IsActive = true },
        new Employee { Id = 13, Name = "Thomas Harris", Department = Department.IT, Salary = 79000m, YearsOfExperience = 7, IsRemote = true, HireDate = new DateTime(2017, 12, 8), ManagerId = 1, IsActive = true }
    ];

    public static List<Project> ProjectList { get; } =
    [
        new Project { Id = 1, Name = "Website Redesign", Category = ProjectCategory.WebDevelopment, Budget = 50000m, TeamSize = 5, IsCompleted = true, StartDate = new DateTime(2023, 1, 10), EndDate = new DateTime(2023, 6, 15), Priority = 5, CompletionPercentage = 100.0 },
        new Project { Id = 2, Name = "Mobile App Development", Category = ProjectCategory.Mobile, Budget = 120000m, TeamSize = 8, IsCompleted = false, StartDate = new DateTime(2024, 3, 1), EndDate = null, Priority = 5, CompletionPercentage = 65.5 },
        new Project { Id = 3, Name = "Database Migration", Category = ProjectCategory.Infrastructure, Budget = 35000m, TeamSize = 3, IsCompleted = true, StartDate = new DateTime(2023, 5, 12), EndDate = new DateTime(2023, 8, 20), Priority = 4, CompletionPercentage = 100.0 },
        new Project { Id = 4, Name = "CRM Integration", Category = ProjectCategory.Integration, Budget = 75000m, TeamSize = 6, IsCompleted = false, StartDate = new DateTime(2024, 2, 15), EndDate = null, Priority = 3, CompletionPercentage = 45.0 },
        new Project { Id = 5, Name = "Marketing Analytics", Category = ProjectCategory.Analytics, Budget = 42000m, TeamSize = 4, IsCompleted = false, StartDate = new DateTime(2024, 4, 5), EndDate = null, Priority = 2, CompletionPercentage = 30.0 },
        new Project { Id = 6, Name = "Security Audit", Category = ProjectCategory.Security, Budget = 28000m, TeamSize = 2, IsCompleted = true, StartDate = new DateTime(2023, 9, 1), EndDate = new DateTime(2023, 11, 30), Priority = 5, CompletionPercentage = 100.0 },
        new Project { Id = 7, Name = "E-commerce Platform", Category = ProjectCategory.WebDevelopment, Budget = 150000m, TeamSize = 12, IsCompleted = false, StartDate = new DateTime(2024, 1, 8), EndDate = null, Priority = 5, CompletionPercentage = 78.5 },
        new Project { Id = 8, Name = "Cloud Migration", Category = ProjectCategory.Infrastructure, Budget = 95000m, TeamSize = 7, IsCompleted = false, StartDate = new DateTime(2024, 5, 1), EndDate = null, Priority = 4, CompletionPercentage = 22.0 },
        new Project { Id = 9, Name = "AI Chatbot", Category = ProjectCategory.AI_ML, Budget = 68000m, TeamSize = 5, IsCompleted = true, StartDate = new DateTime(2023, 7, 15), EndDate = new DateTime(2024, 1, 10), Priority = 3, CompletionPercentage = 100.0 },
        new Project { Id = 10, Name = "HR Portal", Category = ProjectCategory.WebDevelopment, Budget = 45000m, TeamSize = 4, IsCompleted = false, StartDate = new DateTime(2024, 3, 20), EndDate = null, Priority = 2, CompletionPercentage = 55.0 },
        new Project { Id = 11, Name = "Inventory System", Category = ProjectCategory.EnterpriseSoftware, Budget = 82000m, TeamSize = 6, IsCompleted = true, StartDate = new DateTime(2023, 2, 5), EndDate = new DateTime(2023, 10, 12), Priority = 4, CompletionPercentage = 100.0 },
        new Project { Id = 12, Name = "API Gateway", Category = ProjectCategory.Integration, Budget = 38000m, TeamSize = 3, IsCompleted = false, StartDate = new DateTime(2024, 4, 18), EndDate = null, Priority = 3, CompletionPercentage = 38.0 },
        new Project { Id = 13, Name = "Data Warehouse", Category = ProjectCategory.Analytics, Budget = 110000m, TeamSize = 9, IsCompleted = false, StartDate = new DateTime(2024, 2, 1), EndDate = null, Priority = 4, CompletionPercentage = 62.5 }
    ];

    public static List<Book> BookList { get; } =
    [
        new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = BookGenre.Classic, Price = 12.99m, Pages = 180, IsAvailable = true, PublicationDate = new DateTime(1925, 4, 10), Rating = 4.5, CopiesInStock = 25 },
        new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = BookGenre.Classic, Price = 14.99m, Pages = 324, IsAvailable = true, PublicationDate = new DateTime(1960, 7, 11), Rating = 4.8, CopiesInStock = 18 },
        new Book { Id = 3, Title = "1984", Author = "George Orwell", Genre = BookGenre.ScienceFiction, Price = 13.99m, Pages = 328, IsAvailable = false, PublicationDate = new DateTime(1949, 6, 8), Rating = 4.7, CopiesInStock = 0 },
        new Book { Id = 4, Title = "Pride and Prejudice", Author = "Jane Austen", Genre = BookGenre.Romance, Price = 11.99m, Pages = 432, IsAvailable = true, PublicationDate = new DateTime(1813, 1, 28), Rating = 4.6, CopiesInStock = 32 },
        new Book { Id = 5, Title = "The Hobbit", Author = "J.R.R. Tolkien", Genre = BookGenre.Fantasy, Price = 15.99m, Pages = 310, IsAvailable = true, PublicationDate = new DateTime(1937, 9, 21), Rating = 4.7, CopiesInStock = 45 },
        new Book { Id = 6, Title = "Harry Potter and the Sorcerer's Stone", Author = "J.K. Rowling", Genre = BookGenre.Fantasy, Price = 16.99m, Pages = 309, IsAvailable = true, PublicationDate = new DateTime(1997, 6, 26), Rating = 4.9, CopiesInStock = 62 },
        new Book { Id = 7, Title = "The Da Vinci Code", Author = "Dan Brown", Genre = BookGenre.Thriller, Price = 14.99m, Pages = 489, IsAvailable = true, PublicationDate = new DateTime(2003, 3, 18), Rating = 4.2, CopiesInStock = 28 },
        new Book { Id = 8, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Genre = BookGenre.Classic, Price = 13.99m, Pages = 234, IsAvailable = false, PublicationDate = new DateTime(1951, 7, 16), Rating = 3.8, CopiesInStock = 0 },
        new Book { Id = 9, Title = "The Alchemist", Author = "Paulo Coelho", Genre = BookGenre.Fiction, Price = 12.99m, Pages = 208, IsAvailable = true, PublicationDate = new DateTime(1988, 5, 1), Rating = 4.3, CopiesInStock = 38 },
        new Book { Id = 10, Title = "The Hunger Games", Author = "Suzanne Collins", Genre = BookGenre.ScienceFiction, Price = 15.99m, Pages = 374, IsAvailable = true, PublicationDate = new DateTime(2008, 9, 14), Rating = 4.6, CopiesInStock = 41 },
        new Book { Id = 11, Title = "Gone Girl", Author = "Gillian Flynn", Genre = BookGenre.Thriller, Price = 14.99m, Pages = 432, IsAvailable = false, PublicationDate = new DateTime(2012, 6, 5), Rating = 4.1, CopiesInStock = 0 },
        new Book { Id = 12, Title = "The Book Thief", Author = "Markus Zusak", Genre = BookGenre.HistoricalFiction, Price = 13.99m, Pages = 552, IsAvailable = true, PublicationDate = new DateTime(2005, 9, 1), Rating = 4.7, CopiesInStock = 22 },
        new Book { Id = 13, Title = "Sapiens", Author = "Yuval Noah Harari", Genre = BookGenre.NonFiction, Price = 18.99m, Pages = 512, IsAvailable = true, PublicationDate = new DateTime(2011, 6, 1), Rating = 4.6, CopiesInStock = 34 }
    ];

    // EmployeeProject Relationships (13 diverse records)
    public static List<EmployeeProject> EmployeeProjectList { get; } =
    [
        // Project 2 (Mobile App) - 3 team members with different roles
        new EmployeeProject { Id = 1, EmployeeId = 1, ProjectId = 2, Role = ProjectRole.Lead, HoursAllocated = 160, AssignedDate = new DateTime(2024, 3, 1), IsActive = true },
        new EmployeeProject { Id = 2, EmployeeId = 3, ProjectId = 2, Role = ProjectRole.Developer, HoursAllocated = 120, AssignedDate = new DateTime(2024, 3, 5), IsActive = true },
        new EmployeeProject { Id = 3, EmployeeId = 5, ProjectId = 2, Role = ProjectRole.Tester, HoursAllocated = 80, AssignedDate = new DateTime(2024, 3, 10), IsActive = true },
        
        // Project 7 (E-commerce) - Large team with diverse roles
        new EmployeeProject { Id = 4, EmployeeId = 13, ProjectId = 7, Role = ProjectRole.Architect, HoursAllocated = 140, AssignedDate = new DateTime(2024, 1, 8), IsActive = true },
        new EmployeeProject { Id = 5, EmployeeId = 3, ProjectId = 7, Role = ProjectRole.Developer, HoursAllocated = 160, AssignedDate = new DateTime(2024, 1, 10), IsActive = true },
        
        // Project 8 (Cloud Migration) - Infrastructure team
        new EmployeeProject { Id = 6, EmployeeId = 1, ProjectId = 8, Role = ProjectRole.DevOps, HoursAllocated = 100, AssignedDate = new DateTime(2024, 5, 1), IsActive = true },
        new EmployeeProject { Id = 7, EmployeeId = 5, ProjectId = 8, Role = ProjectRole.Developer, HoursAllocated = 120, AssignedDate = new DateTime(2024, 5, 5), IsActive = true },
        
        // Project 5 (Marketing Analytics) - Marketing & IT collaboration
        new EmployeeProject { Id = 8, EmployeeId = 6, ProjectId = 5, Role = ProjectRole.Lead, HoursAllocated = 140, AssignedDate = new DateTime(2024, 4, 5), IsActive = true },
        new EmployeeProject { Id = 9, EmployeeId = 11, ProjectId = 5, Role = ProjectRole.Analyst, HoursAllocated = 100, AssignedDate = new DateTime(2024, 4, 10), IsActive = true },
        
        // Project 13 (Data Warehouse) - Finance analysts
        new EmployeeProject { Id = 10, EmployeeId = 4, ProjectId = 13, Role = ProjectRole.Lead, HoursAllocated = 160, AssignedDate = new DateTime(2024, 2, 1), IsActive = true },
        new EmployeeProject { Id = 11, EmployeeId = 9, ProjectId = 13, Role = ProjectRole.Analyst, HoursAllocated = 140, AssignedDate = new DateTime(2024, 2, 5), IsActive = true },
        
        // Completed project (inactive assignment)
        new EmployeeProject { Id = 12, EmployeeId = 1, ProjectId = 1, Role = ProjectRole.Lead, HoursAllocated = 160, AssignedDate = new DateTime(2023, 1, 10), IsActive = false },
        
        // Multiple projects for same employee
        new EmployeeProject { Id = 13, EmployeeId = 3, ProjectId = 4, Role = ProjectRole.Developer, HoursAllocated = 80, AssignedDate = new DateTime(2024, 2, 20), IsActive = true }
    ];

    // BookLoan Relationships (13 diverse records)
    public static List<BookLoan> BookLoanList { get; } =
    [
        // Returned on time
        new BookLoan { Id = 1, EmployeeId = 1, BookId = 6, LoanDate = new DateTime(2024, 1, 15), DueDate = new DateTime(2024, 2, 15), ReturnDate = new DateTime(2024, 2, 10), IsReturned = true, LateFee = null },
        new BookLoan { Id = 2, EmployeeId = 2, BookId = 4, LoanDate = new DateTime(2024, 1, 20), DueDate = new DateTime(2024, 2, 20), ReturnDate = new DateTime(2024, 2, 18), IsReturned = true, LateFee = null },
        
        // Returned late with fees
        new BookLoan { Id = 3, EmployeeId = 3, BookId = 10, LoanDate = new DateTime(2024, 2, 1), DueDate = new DateTime(2024, 3, 1), ReturnDate = new DateTime(2024, 3, 5), IsReturned = true, LateFee = 2.00m },
        new BookLoan { Id = 4, EmployeeId = 7, BookId = 7, LoanDate = new DateTime(2024, 2, 5), DueDate = new DateTime(2024, 3, 5), ReturnDate = new DateTime(2024, 3, 20), IsReturned = true, LateFee = 7.50m },
        new BookLoan { Id = 5, EmployeeId = 13, BookId = 1, LoanDate = new DateTime(2024, 2, 20), DueDate = new DateTime(2024, 3, 20), ReturnDate = new DateTime(2024, 4, 5), IsReturned = true, LateFee = 8.00m },
        
        // Currently borrowed (not returned)
        new BookLoan { Id = 6, EmployeeId = 5, BookId = 9, LoanDate = new DateTime(2024, 3, 10), DueDate = new DateTime(2024, 4, 10), ReturnDate = null, IsReturned = false, LateFee = null },
        new BookLoan { Id = 7, EmployeeId = 11, BookId = 2, LoanDate = new DateTime(2024, 3, 15), DueDate = new DateTime(2024, 4, 15), ReturnDate = null, IsReturned = false, LateFee = null },
        new BookLoan { Id = 8, EmployeeId = 4, BookId = 13, LoanDate = new DateTime(2024, 3, 1), DueDate = new DateTime(2024, 4, 1), ReturnDate = null, IsReturned = false, LateFee = null },
        
        // Same employee multiple loans
        new BookLoan { Id = 9, EmployeeId = 1, BookId = 5, LoanDate = new DateTime(2024, 2, 25), DueDate = new DateTime(2024, 3, 25), ReturnDate = new DateTime(2024, 3, 20), IsReturned = true, LateFee = null },
        new BookLoan { Id = 10, EmployeeId = 3, BookId = 12, LoanDate = new DateTime(2024, 1, 5), DueDate = new DateTime(2024, 2, 5), ReturnDate = new DateTime(2024, 2, 3), IsReturned = true, LateFee = null },
        
        // Different genres
        new BookLoan { Id = 11, EmployeeId = 9, BookId = 12, LoanDate = new DateTime(2024, 2, 10), DueDate = new DateTime(2024, 3, 10), ReturnDate = new DateTime(2024, 3, 8), IsReturned = true, LateFee = null },
        new BookLoan { Id = 12, EmployeeId = 6, BookId = 7, LoanDate = new DateTime(2024, 1, 25), DueDate = new DateTime(2024, 2, 25), ReturnDate = new DateTime(2024, 2, 24), IsReturned = true, LateFee = null },
        new BookLoan { Id = 13, EmployeeId = 10, BookId = 4, LoanDate = new DateTime(2024, 3, 5), DueDate = new DateTime(2024, 4, 5), ReturnDate = null, IsReturned = false, LateFee = null }
    ];
}