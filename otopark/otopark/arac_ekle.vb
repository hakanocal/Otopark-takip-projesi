﻿Imports System.Data.OleDb
Imports System.Data

Public Class arac_ekle
    Dim src = anasayfa.src
    Dim park_adi = anasayfa.park_adi
    Dim arac_ekle As String = " ARAÇ EKLE"
    Dim baglanti As New OleDbConnection("Provider=sqloledb;Data Source=" & src & ";Initial Catalog=otopark;Integrated Security=SSPI;")

    Private Sub parkkontrol()
        Dim park_yeri_arti(20) As Button
        park_yeri_arti(1) = anasayfa.p1
        park_yeri_arti(2) = anasayfa.p2
        park_yeri_arti(3) = anasayfa.p3
        park_yeri_arti(4) = anasayfa.p4
        park_yeri_arti(5) = anasayfa.p5
        park_yeri_arti(6) = anasayfa.p6
        park_yeri_arti(7) = anasayfa.p7
        park_yeri_arti(8) = anasayfa.p8
        park_yeri_arti(9) = anasayfa.p9
        park_yeri_arti(10) = anasayfa.p10
        park_yeri_arti(11) = anasayfa.p11
        park_yeri_arti(12) = anasayfa.p12
        park_yeri_arti(13) = anasayfa.p13
        park_yeri_arti(14) = anasayfa.p14
        park_yeri_arti(15) = anasayfa.p15
        park_yeri_arti(16) = anasayfa.p16
        park_yeri_arti(17) = anasayfa.p17
        park_yeri_arti(18) = anasayfa.p18
        park_yeri_arti(19) = anasayfa.p19
        park_yeri_arti(20) = anasayfa.p20



        Dim park_yeri(20) As Button
        park_yeri(1) = anasayfa.Button1
        park_yeri(2) = anasayfa.Button2
        park_yeri(3) = anasayfa.Button3
        park_yeri(4) = anasayfa.Button4
        park_yeri(5) = anasayfa.Button5
        park_yeri(6) = anasayfa.Button6
        park_yeri(7) = anasayfa.Button7
        park_yeri(8) = anasayfa.Button8
        park_yeri(9) = anasayfa.Button9
        park_yeri(10) = anasayfa.Button10
        park_yeri(11) = anasayfa.Button11
        park_yeri(12) = anasayfa.Button12
        park_yeri(13) = anasayfa.Button13
        park_yeri(14) = anasayfa.Button14
        park_yeri(15) = anasayfa.Button15
        park_yeri(16) = anasayfa.Button16
        park_yeri(17) = anasayfa.Button17
        park_yeri(18) = anasayfa.Button18
        park_yeri(19) = anasayfa.Button19
        park_yeri(20) = anasayfa.Button20

        Dim komut As New OleDbCommand("select * from araclar", baglanti)
        Dim veriokuyucu As OleDbDataReader
        baglanti.Open()
        veriokuyucu = komut.ExecuteReader
        Do While veriokuyucu.Read
            For i = 1 To 20
                If veriokuyucu("park_yeri") = park_yeri(i).Text Then
                    park_yeri(i).Enabled = True
                    park_yeri(i).BackColor = Color.Red
                    park_yeri_arti(i).Visible = False
                    park_yeri(i).Text = park_yeri(i).Text + Chr(13) + veriokuyucu("plaka")
                End If
            Next
        Loop
        baglanti.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim komut As New OleDbCommand("insert into araclar(plaka, marka, model, renk, tc, ad, soyad, telefon, email, park_yeri, giris_tarihi, giris_saati) values('" & plaka.Text & "', '" & marka.Text & "', '" & model.Text & "', '" & renk.Text & "', '" & tc.Text & "', '" & ad.Text & "', '" & soyad.Text & "', '" & telefon.Text & "', '" & email.Text & "', '" & park_adi & "', '" & Today & "' , '" & TimeOfDay & "')", baglanti)
        If plaka.Text = "" Or marka.Text = "" Or model.Text = "" Or renk.Text = "" Then
            MsgBox("Araç bilgileri boş geçilemez", MsgBoxStyle.Critical, "Uyarı")
        Else
            baglanti.Open()
            komut.ExecuteNonQuery()
            baglanti.Close()
            MsgBox("Başarılı", MsgBoxStyle.Information, "Başarılı")
            parkkontrol()
            Me.Close()
        End If


    End Sub

    Private Sub arac_ekle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label6.Text = park_adi + arac_ekle
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class