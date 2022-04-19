Public Class Form1
    Dim Nombre As String
    Dim Tiempo As String
    Dim Tecla As String
    Dim VCierre As String
    Dim GuardCierre As Integer
    Dim Ruta As String
    Dim Terminado As Boolean = False
    Dim File As System.IO.StreamWriter

    

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MsgBox("Bienvenido, antes de crear el script hay que definir ciertos parámetros, puede cancelar al final del formulario", vbOKOnly, "Introducción")

        ' Tiempo entre inputs en milisegundos (ms)
        Tiempo = ""
        While IsNumeric(Tiempo) = False
            Tiempo = InputBox("Tiempo en milisegundos (ms) entre cada dato y Enter. 200 mínimo recomendado, puede poner un valor más alto para verlo cargar todo correctamente", "Definir tiempo entre datos", "200")
        End While

        ' Tecla a utilizar
        Tecla = "F7"
        Tecla = InputBox("Tecla para activar el script, se recomienda alguna que no se use con frecuencia, por defecto F7. Se recomiendan las teclas de Función y utilizar mayúscula", "Definir tecla", "F7")

        ' Valor para cerrar
        VCierre = 0
        VCierre = InputBox("Valor que se utilizara de cierre, puede ser 0, XX, etc. Para terminar de cargar datos tendrá que introducir dicho valor", "Definir valor cierre", "0")

        ' Elije si quiere guardar al final o no el valor de cierre
        GuardCierre = MsgBox("¿Crear el script SIN cargar el valor de cierre (" & VCierre & ") al final? (para corte de control por ejemplo)", MsgBoxStyle.YesNo)
        If GuardCierre = vbYes Then
            GuardCierre = 0
            MsgBox("El valor NO se cargará a lo último", MsgBoxStyle.OkOnly)
        ElseIf GuardCierre = vbNo Then
            GuardCierre = 1
            MsgBox("El último valor será " & VCierre, MsgBoxStyle.OkOnly)
        End If

        ' Nombre del archivo
        Nombre = InputBox("Nombre o sufijo del archivo (el output será <tecla> - <nombre>)", "Definir Nombre")
        Nombre = Tecla & " - " & Nombre & ".ahk"

        ' Opcion guardar dentro del zip o .exe standalone

        MsgBox("Si está usando el programa desde el zip, se recomienda que guarde en la carpeta que viene incluida. Si está utilizando esta aplicación standalone desde el ejecutable (sin el proyecto) entonces se utilizará una carpeta en el mismo directorio (si no se creó antes). Puede también elegir no usar carpeta", MsgBoxStyle.Information)
        If (MsgBox("¿Está utilizando el programa desde el .zip?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
            ' Ruta si está en zip
            Ruta = "..\..\..\Scripts Resultado\"
        ElseIf (MsgBox("¿Quiere crear la carpeta <Scripts Resultado>?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
            ' Ruta directa (concarpeta)
            Ruta = ".\Scripts Resultado\"
        Else
            ' Ruta directa (sin carpeta)
            Ruta = ".\"
        End If

        ' Borrar archivo viejo si existe o cambiar nombre
        While System.IO.File.Exists(Ruta & Nombre)
            If (MsgBox("Ya hay un archivo con el mismo nombre, ¿Desea eliminarlo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
                System.IO.File.Delete(Ruta & Nombre)
                MsgBox("Archivo viejo borrado", MsgBoxStyle.Information)
            Else
                Nombre = InputBox("Ingrese un nombre distinto (el output será <tecla> - <nombre>)", "Renombrar")
                Nombre = Tecla & " - " & Nombre & ".ahk"
            End If
        End While

        ' Crear carpeta si no existe
        If ((Ruta <> ".\") And (Not System.IO.Directory.Exists(Ruta))) Then
            System.IO.Directory.CreateDirectory(Ruta)
        End If



        ' Abrir (instanciar) archivo
        File = My.Computer.FileSystem.OpenTextFileWriter(Ruta & Nombre, True)

        ' Escribir configuraciones
        With File
            .WriteLine("#SingleInstance Force ")
            .WriteLine("#NoEnv ")
            .WriteLine("SendMode Input ")
            .WriteLine("SetWorkingDir %A_ScriptDir% ")
            .WriteLine("Tiempo = " & Tiempo)
            .WriteLine("")
            .WriteLine("")
            .WriteLine(Tecla & "::")
        End With
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Text As String

        Text = "a"
        While Text <> VCierre

            Text = InputBox("Ingresar texto", "Text", VCierre)

            ' Verificar que no quede vacío
            If Text <> "" Then
                If GuardCierre = 1 Then ' Ejecucion guardando último valor
                    ListBox1.Items.Add(Text)
                    With File
                        .WriteLine("")
                        .WriteLine("Send, " & Text)
                        .WriteLine("Send {Enter}")
                        .WriteLine("Sleep, %Tiempo%")
                    End With

                ElseIf GuardCierre = 0 Then ' Ejecucion sin guardar ultimo valor
                    If Text <> VCierre Then ' Solo verifica extra
                        ListBox1.Items.Add(Text)
                        With File
                            .WriteLine("")
                            .WriteLine("Send, " & Text)
                            .WriteLine("Send {Enter}")
                            .WriteLine("Sleep, %Tiempo%")
                        End With
                    End If
                End If
            End If

        End While

    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancelar.Click
        ' Operación cancelada
        File.Close()
        Me.Close()
    End Sub

    Private Sub Form1_CerrarOCancelar(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Terminado = False Then
            System.IO.File.Delete(Ruta & Nombre)
            MsgBox("Script cancelado", MsgBoxStyle.Exclamation)
        End If

        ' Operación cancelada        
        Me.Hide()

    End Sub

    Private Sub Terminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Terminar.Click

        ' Operación exitosa
        Terminado = True
        File.Close()
        MsgBox("Gracias, recuerde que para utilizar el script se requiere AutoHotKey", MsgBoxStyle.MsgBoxRight)
        Me.Close()

    End Sub

    
End Class
