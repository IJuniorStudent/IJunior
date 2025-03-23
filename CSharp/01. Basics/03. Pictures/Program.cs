namespace Practice_3;

class Program
{
    static void Main(string[] args)
    {
        int totalPicturesInAlbum = 52;
        int picturesPerLine = 3;
        
        int albumFullLinesCount = totalPicturesInAlbum / picturesPerLine;
        int albumLastLinePicturesCount = totalPicturesInAlbum % picturesPerLine;
        
        Console.WriteLine($"В альбоме всего картинок: {totalPicturesInAlbum}");
        Console.WriteLine($"Количество заполненных рядов с картинками: {albumFullLinesCount}");
        Console.WriteLine($"Количество картинок, занимающих неполный ряд: {albumLastLinePicturesCount}");
    }
}
