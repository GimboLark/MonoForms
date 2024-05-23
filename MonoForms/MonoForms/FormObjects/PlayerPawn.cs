using System.Windows.Forms;
using System.Drawing;
using MonoForms.Utils;

namespace MonoForms.FormObjects
{
    // bu playerin seçtiği imagi gösterecek
    public class PlayerPawn : Control
    {

        // image string name
        public string imageName;

        // picture box
        public PictureBox pawnImage;

        public PlayerPawn(Player player)
        {
            this.imageName = player.imageName;

            pawnImage = new PictureBox();
            pawnImage.Bounds = new Rectangle(0, 0, 20, 20);
            pawnImage.BackgroundImage = Image.FromFile($"../../Assets/Pawn/{imageName}.png");
            pawnImage.BackgroundImageLayout = ImageLayout.Stretch;

            this.Controls.Add(pawnImage);

        }
    }
}
