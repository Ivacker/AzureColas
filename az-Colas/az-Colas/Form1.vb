'@ivacker
'******************************
'Ejemplo de uso del servicio de colas en Azure Storage
'Se utiliza el NuGet "WindowsAzure.Storage"
'
'Aporte para la comunidad de Clouder de Azure.
'http://ivacker.cl
'Update 2015-10-03
''******************************


Imports Microsoft.WindowsAzure.Storage
Imports Microsoft.WindowsAzure.Storage.Auth
Imports Microsoft.WindowsAzure.Storage.Queue

Public Class Form1

    'Declaraciones
    Private m_csa_storageAccount As CloudStorageAccount 'Creo el objeto para el manejo de autenticacion
    Dim sNombreCola As String = Nothing

    Public ReadOnly Property Csa_storageAccount() As CloudStorageAccount
        Get
            If m_csa_storageAccount Is Nothing Then
                Dim strAccount As String = My.Settings.sCuenta 'Asigno el nombre de la cuenta de Almacenamiento
                Dim strKey As String = My.Settings.sKey 'Asigno la Key de acceso

                Dim credential As New StorageCredentials(strAccount, strKey) 'Creo el objeto credenciales
                m_csa_storageAccount = New CloudStorageAccount(credential, True) 'Asigno las credenciales a la cuenta
            End If
            Return m_csa_storageAccount
        End Get

    End Property

    Sub CREARCola()

        Try
            Dim cClient As CloudQueueClient = Csa_storageAccount.CreateCloudQueueClient 'Creo el objeto cliente
            Dim Queue = cClient.GetQueueReference(My.Settings.sNombreCola.ToString) 'Obtengo el objeto cola
            Queue.CreateIfNotExists() ' Creo la cola si no existe
            MsgBox("Cola creada: " & sNombreCola.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString,, "Error")
        End Try

    End Sub
    Sub PUTCola(ByVal sMensaje As String)

        Try
            Dim cClient As CloudQueueClient = Csa_storageAccount.CreateCloudQueueClient 'Creo el objeto cliente
            Dim Queue = cClient.GetQueueReference(My.Settings.sNombreCola.ToString) 'Obtengo el objeto cola

            Dim Message As New CloudQueueMessage(sMensaje) 'Creo el objeto mensaje
            Queue.AddMessage(Message) ' Coloco el mensaje en la cola
        Catch ex As Exception
            MsgBox(ex.Message.ToString,, "Error")
        End Try

    End Sub

    Sub GETCola()

        Dim cClient As CloudQueueClient = Csa_storageAccount.CreateCloudQueueClient 'Creo el objeto cliente
        Dim Queue = cClient.GetQueueReference(My.Settings.sNombreCola.ToString) 'Obtengo el objeto cola

        ' obtener mensaje
        Dim retrievedMessage = Queue.GetMessage 'Obtengo el mensaje desde la cola
        Dim sMensaje As String = Nothing

        Try
            Queue.GetMessage(TimeSpan.FromSeconds(10)) 'Obtengo el mensaje y lo retengo por x segundos
            sMensaje = "Mensaje: " & retrievedMessage.AsString & vbCrLf & vbCrLf 'Mensaje
            sMensaje = sMensaje & "ID: " & retrievedMessage.Id & vbCrLf 'ID del mensaje
            sMensaje = sMensaje & "DCount: " & retrievedMessage.DequeueCount & vbCrLf 'Count de veces que el mensaje fue leido
            sMensaje = sMensaje & "InsertionTime: " & retrievedMessage.InsertionTime.ToString & vbCrLf  'Fecha de creacion
            sMensaje = sMensaje & "NextVisibleTime: " & retrievedMessage.NextVisibleTime.ToString & vbCrLf  'Tiempo para volver a estar visible
            sMensaje = sMensaje & "PopReceipt: " & retrievedMessage.PopReceipt & vbCrLf 'PopReceipt

            MsgBox(sMensaje.ToString)
        Catch ex As Exception
            MsgBox(ex.Message.ToString,, "Error")
        End Try

    End Sub

    Sub ELIMINACola()

        Dim cClient As CloudQueueClient = Csa_storageAccount.CreateCloudQueueClient 'Creo el objeto cliente
        Dim Queue = cClient.GetQueueReference(My.Settings.sNombreCola.ToString) 'Obtengo el objeto cola

        ' obtener mensaje
        Dim retrievedMessage = Queue.GetMessage 'Obtengo el mensaje desde la cola

        Try
            Queue.DeleteMessage(retrievedMessage.Id.ToString, retrievedMessage.PopReceipt) 'Elimino el mensaje desde la cola indicando el ID
            MsgBox("Mensaje borrado de la cola :" & retrievedMessage.Id.ToString) 'Visualizo el ID del mensaje eliminado
        Catch ex As Exception
            MsgBox(ex.Message.ToString,, "Error")
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCrearCola.Click

        sNombreCola = InputBox("Escriba el nombre para la Cola:", "Crear Cola de Mensajes")

        If sNombreCola.Length > 0 Then
            My.Settings.sNombreCola = sNombreCola.ToString
            My.Settings.Save()
            CREARCola()
        Else
            MsgBox("Debe ingresar un nombre para la cola, no se creo la cola",, "Aviso")
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCrearMensajeCola.Click

        PUTCola(InputBox("Escriba el mensaje para la cola:", "Crear Mensaje en cola"))
        MsgBox("Mensaje Creado")

    End Sub

    Private Sub btnLeerMensajeCola_Click(sender As Object, e As EventArgs) Handles btnLeerMensajeCola.Click
        GETCola()
    End Sub

    Private Sub btnEliminarMensaje_Click(sender As Object, e As EventArgs) Handles btnEliminarMensaje.Click
        ELIMINACola()
    End Sub
End Class
