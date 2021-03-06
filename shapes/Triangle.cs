using System.Drawing;

public class Triangle {
    Color Color { get; set; }
    int SideA { get; set; }
    int SideB { get; set; }
    int SideC { get; set; }
    public int xPosition { get; set; }
    public int yPosition { get; set; }

    public void Spin(Direction spinDirection, int spins) {
        var degrees = 360 * spins;
        switch (spinDirection) {
            case Direction.Horizonal:
            this.xPosition = degrees;
            break;
            case Direction.Veritical:
            this.yPosition = degrees;
            break;
        }
    }

    public (int, int) GetCurrentPosition() {
        return (this.xPosition, this.yPosition);
    }

    public enum Direction {
        Horizonal,
        Veritical
    }
}