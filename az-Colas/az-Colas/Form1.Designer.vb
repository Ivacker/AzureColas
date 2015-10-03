<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnCrearCola = New System.Windows.Forms.Button()
        Me.btnCrearMensajeCola = New System.Windows.Forms.Button()
        Me.btnLeerMensajeCola = New System.Windows.Forms.Button()
        Me.btnEliminarMensaje = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCrearCola
        '
        Me.btnCrearCola.Location = New System.Drawing.Point(12, 23)
        Me.btnCrearCola.Name = "btnCrearCola"
        Me.btnCrearCola.Size = New System.Drawing.Size(156, 25)
        Me.btnCrearCola.TabIndex = 0
        Me.btnCrearCola.Text = "Crear Cola"
        Me.btnCrearCola.UseVisualStyleBackColor = True
        '
        'btnCrearMensajeCola
        '
        Me.btnCrearMensajeCola.Location = New System.Drawing.Point(12, 54)
        Me.btnCrearMensajeCola.Name = "btnCrearMensajeCola"
        Me.btnCrearMensajeCola.Size = New System.Drawing.Size(156, 25)
        Me.btnCrearMensajeCola.TabIndex = 1
        Me.btnCrearMensajeCola.Text = "Crear Mensaje en Cola"
        Me.btnCrearMensajeCola.UseVisualStyleBackColor = True
        '
        'btnLeerMensajeCola
        '
        Me.btnLeerMensajeCola.Location = New System.Drawing.Point(12, 85)
        Me.btnLeerMensajeCola.Name = "btnLeerMensajeCola"
        Me.btnLeerMensajeCola.Size = New System.Drawing.Size(156, 25)
        Me.btnLeerMensajeCola.TabIndex = 3
        Me.btnLeerMensajeCola.Text = "Leer Mensaje en Cola"
        Me.btnLeerMensajeCola.UseVisualStyleBackColor = True
        '
        'btnEliminarMensaje
        '
        Me.btnEliminarMensaje.Location = New System.Drawing.Point(12, 116)
        Me.btnEliminarMensaje.Name = "btnEliminarMensaje"
        Me.btnEliminarMensaje.Size = New System.Drawing.Size(156, 25)
        Me.btnEliminarMensaje.TabIndex = 4
        Me.btnEliminarMensaje.Text = "Eliminar Mensaje en Cola"
        Me.btnEliminarMensaje.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 301)
        Me.Controls.Add(Me.btnEliminarMensaje)
        Me.Controls.Add(Me.btnLeerMensajeCola)
        Me.Controls.Add(Me.btnCrearMensajeCola)
        Me.Controls.Add(Me.btnCrearCola)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Form1"
        Me.Text = "@ivacker - Uso de colas con Azure Storage"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCrearCola As Button
    Friend WithEvents btnCrearMensajeCola As Button
    Friend WithEvents btnLeerMensajeCola As Button
    Friend WithEvents btnEliminarMensaje As Button
End Class
