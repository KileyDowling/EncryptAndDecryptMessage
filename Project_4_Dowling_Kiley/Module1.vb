Option Strict On
Imports System
Module Module1

    Sub Main()
        'data controls
        Const _EXIT As Integer = 3

        'user selections
        Dim userChoice As Integer
        Dim userInput As String
        Dim validInput As String
        Dim result As String

        'start program
        userChoice = ProgramControl()

        While (userChoice <> _EXIT)
            'accept user input
            userInput = acceptUserInput()
            'check if valid
            validInput = validateUserInput(userInput)

            If (validInput = userInput) Then
                'Encrypt or decrypt
                result = EncryptOrDecrypt(validInput, userChoice)
                Console.WriteLine("RESULT: {0}", result)

                'allow user to choose to continue
                userChoice = ProgramControl()
            Else
                Console.WriteLine(validInput)
            End If
        End While

        Console.Write("Program end. Good-bye!")
        Console.ReadLine()
    End Sub

    Function ProgramControl() As Integer
        'program controls
        Dim _option As Integer
        Dim encrypt As Integer = 1
        Dim decrypt As Integer = 2
        Dim _EXIT As Integer = 3
        Dim userSelection As String = "-1"
        Dim numCheck As Boolean = False

        numCheck = IsNumeric(userSelection)

        While (numCheck)
            Console.WriteLine(" 1. Encrypt ")
            Console.WriteLine(" 2. Decrypt ")
            Console.WriteLine(" 3. Exit ")

            userSelection = Console.ReadLine()
            If (IsNumeric(userSelection)) Then
                If (CInt(userSelection) < 4) And (CInt(userSelection) > 0) Then
                    _option = CInt(userSelection)
                    numCheck = False
                Else
                    userSelection = "3"
                    _option = CInt(userSelection)
                End If

            Else
                userSelection = "3"
                _option = CInt(userSelection)
            End If

        End While

            Return _option

    End Function

    Function acceptUserInput() As String
        Dim data As String

        Console.Write("ENTER A STRING OF TEXT: ")
        data = Console.ReadLine()
        Return data

    End Function

    Function validateUserInput(userInput As String) As String
        Dim MAX_SIZE As Integer
        Dim errorMessage As String
        errorMessage = "**ERROR. Too many characters entered"

        'store size of string
        MAX_SIZE = userInput.Length

        'return string
        If (MAX_SIZE <= 200) Then
            Return userInput
        Else
            Return errorMessage
        End If

    End Function


    Function EncryptOrDecrypt(data As String, userChoice As Integer) As String
        Dim searchKey As Char
        Dim MAX_SIZE As Integer = data.Length
        Dim result(MAX_SIZE) As Char
        Dim _foundLocation As Integer
        Dim temp(199) As Char
        Dim KEY_SIZE As Integer = 25

        'encrypting & mapping keys
        Dim _encryptionKey() As Char = {"M"c, "L"c, "K"c, "J"c, "I"c, "H"c, "T"c, "F"c, "E"c, "D"c, "C"c, "B"c, "A"c, "Z"c, "Y"c, "X"c, "W"c, "V"c, "U"c, "G"c, "S"c, "R"c, "Q"c, "P"c, "O"c, "N"c}
        Dim _mappingKey() As Char = {"A"c, "B"c, "C"c, "D"c, "E"c, "F"c, "G"c, "H"c, "I"c, "J"c, "K"c, "L"c, "M"c, "N"c, "O"c, "P"c, "Q"c, "R"c, "S"c, "T"c, "U"c, "V"c, "W"c, "X"c, "Y"c, "Z"c}
        If (userChoice = 1) Then
            Console.WriteLine("Encrypting...[{0}]", data)

            data = data.ToCharArray
            For counter = 0 To (MAX_SIZE - 1)
                temp(counter) = data(counter)
            Next

            For num As Integer = 0 To MAX_SIZE
                searchKey = temp(num)

                For index = 0 To KEY_SIZE
                    If (searchKey = _mappingKey(index)) Then
                        _foundLocation = index
                        temp(num) = _encryptionKey(_foundLocation)
                    End If
                Next
            Next
        ElseIf (userChoice = 2) Then
            Console.WriteLine("Decrypting...[{0}]", data)

            data = data.ToCharArray
            For counter = 0 To (MAX_SIZE - 1)
                temp(counter) = data(counter)
            Next

            For num As Integer = 0 To MAX_SIZE
                searchKey = temp(num)

                For index = 0 To KEY_SIZE
                    If (searchKey = _encryptionKey(index)) Then
                        _foundLocation = index
                        temp(num) = _mappingKey(_foundLocation)
                    End If
                Next
            Next

        End If
        Dim encryptyedMsg As New String(temp)

        Return encryptyedMsg

    End Function

End Module
