namespace VisualCom.Forms.Editor
{
    public partial class MainEditor
    {
        private async void OnImageUnlocked(object? sender, VisComClient.ImageUnlockedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => OnImageUnlocked(sender, e)));
                return;
            }

            bool TryToLock;

            if (Configuration.Connection != null && ImagesList.FocusedItem != null)
            {
                TryToLock = await Configuration.Connection.LockImage(Configuration.ProjectName, ImagesList.FocusedItem.Text);

                Locked = await Configuration.Connection.CheckLock(Configuration.ProjectName, ImagesList.FocusedItem.Text);
                if (Locked)
                    LockedButton.Visible = true;
                else
                    LockedButton.Visible = false;
            }
        }

        private void LockedButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta imagen está bloqueada por lo que no puedes modificarla.");
        }
    }
}
