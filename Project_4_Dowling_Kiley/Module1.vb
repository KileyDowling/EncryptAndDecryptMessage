﻿Option Strict On
Imports System
Module Module1

    Sub Main()
        'encrypting & mapping keys
        Dim _encryptionKey() As Char = {"M"c, "L"c, "K"c, "J"c, "I"c, "H"c, "T"c, "F"c, "E"c, "D"c, "C"c, "B"c, "A"c, "Z"c, "Y"c, "X"c, "W"c, "V"c, "U"c, "G"c, "S"c, "R"c, "Q"c, "P"c, "O"c, "N"c}
        Dim _mappingKey() As Char = {"A"c, "B"c, "C"c, "D"c, "E"c, "F"c, "G"c, "H"c, "I"c, "J"c, "K"c, "L"c, "M"c, "N"c, "O"c, "P"c, "Q"c, "R"c, "S"c, "T"c, "U"c, "V"c, "W"c, "X"c, "Y"c, "Z"c}

        'data controls
        Dim userSelection As String
        Dim userText() As Char
        Dim data As String

        Dim MAX_SIZE As Integer
        Dim KEY_SIZE As Integer = 25

        Dim searchKey As Char
        Dim _foundLocation As Integer

        Dim temp() As Char = {"0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c, "0"c}

        'program controls
        Dim _option As Integer
        Dim encrypt As Integer = 1
        Dim decrypt As Integer = 2
        Dim _EXIT As Integer = 3


        Console.WriteLine(" 1. Encrypt ")
        Console.WriteLine(" 2. Decrypt ")
        Console.WriteLine(" 3. Exit ")

        userSelection = Console.ReadLine()
        _option = CInt(userSelection)

        While (_option <> _EXIT)
            Console.Write("ENTER A STRING OF TEXT: ")
            data = Console.ReadLine()
            userText = data.ToCharArray

            'enrypt
            If (_option = 1) Then
                Console.WriteLine("Encrypting...{0}", data)

                'store size of string
                MAX_SIZE = data.Length

                'assign userinput to temp array up to max size
                If (KEY_SIZE > (MAX_SIZE - 1)) Then
                    For loc As Integer = 0 To (MAX_SIZE - 1)
                        temp(loc) = data(loc)
                    Next
                End If

                For num As Integer = 0 To MAX_SIZE
                    searchKey = temp(num)

                    For index = 0 To KEY_SIZE
                        If (searchKey = _mappingKey(index)) Then
                            _foundLocation = index
                            Console.Write("{0}", _encryptionKey(_foundLocation))
                        End If
                    Next
                Next

                Console.WriteLine("")
            End If


            _option = _EXIT
        End While

        Console.Write("Program end. Good-bye!")

        Console.ReadLine()
    End Sub

End Module