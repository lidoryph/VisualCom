using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using BenchmarkDotNet.Attributes;
using VisualCom;
using Microsoft.VSDiagnostics;

namespace VisualCom.Benchmarks;
[CPUUsageDiagnoser]
public class MainEditorMouseMoveBenchmark
{
    private MainEditor _editor = null!;
    private MethodInfo _mouseMoveMethod = null!;
    private object[] _args = null!;
    [GlobalSetup]
    public void Setup()
    {
        _editor = new MainEditor();
        var pictureBoxField = typeof(MainEditor).GetField("pictureBox", BindingFlags.Instance | BindingFlags.NonPublic);
        var pictureBox = (PictureBox?)pictureBoxField?.GetValue(_editor);
        if (pictureBox != null)
        {
            pictureBox.Size = new Size(1200, 800);
            pictureBox.Image = new Bitmap(1200, 800);
        }

        _mouseMoveMethod = typeof(MainEditor).GetMethod("PictureBox_MouseMove", BindingFlags.Instance | BindingFlags.NonPublic) ?? throw new InvalidOperationException("PictureBox_MouseMove no encontrado.");
        object sender = pictureBox is not null ? pictureBox : _editor;
        _args = [sender, new MouseEventArgs(MouseButtons.None, 0, 500, 300, 0)];
    }

    [Benchmark]
    public void InvokePictureBoxMouseMove()
    {
        _mouseMoveMethod.Invoke(_editor, _args);
    }
}