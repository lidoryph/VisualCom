using VisualCom.Forms.Editor.PullModels;
using VisualCom.Forms.Editor.TrainWindows;

namespace VisualCom.Forms.Editor
{
    public partial class MainEditor
    {
        private void TrainModel(object sender, EventArgs e)
        {
            TrainModel trainmodel = new();
            trainmodel.ShowDialog();
        }

        private void Export(object sender, EventArgs e)
        {
            ExportToYolo dialog = new();
            dialog.ShowDialog();
        }

        private void PullModel(object sender, EventArgs e)
        {
            PullModel dialog = new();
            dialog.ShowDialog();
        }
    }
}
