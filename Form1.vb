Public Class Form1
    Dim maxHealth As Integer
    Dim curHealth As Integer
    Dim curAttackDamage As Integer
    Dim dealtDamage As Integer
    Dim physicalDamage As Integer
    Dim specialDamage As Integer
    Dim totalArmor As Integer
    Dim extraArmor As Integer

    Dim strength As Integer
    Dim dexterity As Integer
    Dim constitution As Integer
    Dim intelligence As Integer
    Dim wisdom As Integer
    Dim charisma As Integer

    Dim psnAmt As Integer
    Dim bleAmt As Integer
    Dim purAmt As Integer
    Dim freAmt As Integer
    Dim freInfluence As Decimal
    Dim diaAmt As Integer

    Dim psnDmg As Integer
    Dim bleDmg As Integer
    Dim purDmg As Integer
    Dim freDmg As Integer
    Dim freSelfDmg As Integer
    Dim diaDmg As Integer
    Dim diaArm As Integer

    Dim psnRes As Decimal
    Dim bleRes As Decimal
    Dim purRes As Decimal
    Dim freRes As Decimal
    Dim diaRes As Decimal

    Dim undead As Boolean = False
    Dim invincible As Boolean = False

    Private Sub Heal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Heal.Click
        maxHealthBox.Text = maxHealth
        curHealth = maxHealth
        currentHealthBox.Text = curHealth
    End Sub

    Private Sub maxHealthBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles maxHealthBox.TextChanged
        If maxHealthBox.Text <> "" Then
            maxHealth = maxHealthBox.Text
            curHealth = maxHealth
            currentHealthBox.Text = curHealth
        End If
    End Sub

    Private Sub attackDamageTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles attackDamageTextBox.TextChanged
        If attackDamageTextBox.Text <> "" Then
            curAttackDamage = attackDamageTextBox.Text
        End If
    End Sub

    Private Sub poisonIncrease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles poisonIncrease.Click
        If psnAmt < 10 Then
            psnAmt = psnAmt + 1
        End If
        poisonAmountTextBox.Text = psnAmt
    End Sub

    Private Sub poisonDecrease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles poisonDecrease.Click
        If psnAmt > 0 Then
            psnAmt = psnAmt - 1
        End If
        poisonAmountTextBox.Text = psnAmt
    End Sub

    Private Sub bleedIncrease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bleedIncrease.Click
        If bleAmt < 10 Then
            bleAmt = bleAmt + 1
        End If
        bleedAmountTextBox.Text = bleAmt
    End Sub

    Private Sub bleedDecrease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bleedDecrease.Click
        If bleAmt > 0 Then
            bleAmt = bleAmt - 1
        End If
        bleedAmountTextBox.Text = bleAmt
    End Sub

    Private Sub pureIncrease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pureIncrease.Click
        If purAmt < 10 Then
            purAmt = purAmt + 1
        End If
        pureAmountTextBox.Text = purAmt
    End Sub

    Private Sub pureDecrease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pureDecrease.Click
        If purAmt > 0 Then
            purAmt = purAmt - 1
        End If
        pureAmountTextBox.Text = purAmt
    End Sub

    Private Sub frenzyIncrease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frenzyIncrease.Click
        If freAmt < 10 Then
            freAmt = freAmt + 1
        End If
        frenzyAmountTextBox.Text = freAmt
    End Sub

    Private Sub frenzyDecrease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frenzyDecrease.Click
        If freAmt > 0 Then
            freAmt = freAmt - 1
        End If
        frenzyAmountTextBox.Text = freAmt
    End Sub

    Private Sub diamondIncrease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles diamondIncrease.Click
        If diaAmt < 10 Then
            diaAmt = diaAmt + 1
        End If
        diamondAmountTextBox.Text = diaAmt
    End Sub

    Private Sub diamondDecrease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles diamondDecrease.Click
        If diaAmt > 0 Then
            diaAmt = diaAmt - 1
        End If
        diamondAmountTextBox.Text = diaAmt
    End Sub

    Private Sub poisonAmountTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles poisonAmountTextBox.TextChanged
        computePsnDamage()
    End Sub

    Private Sub bleedAmountTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bleedAmountTextBox.TextChanged
        computeBleDamage()
    End Sub

    Private Sub pureAmountTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pureAmountTextBox.TextChanged
        computePurDamage()
    End Sub

    Private Sub frenzyAmountTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frenzyAmountTextBox.TextChanged
        computeFrenzyDamage()
    End Sub

    Private Sub diamondAmountTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles diamondAmountTextBox.TextChanged
        computeDiaDamage()
    End Sub

    Private Sub poisonResM25_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles poisonResM25.CheckedChanged
        psnRes = 1.25
        computePsnDamage()
    End Sub

    Private Sub poisonResM50_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles poisonResM50.CheckedChanged
        psnRes = 1.5
        computePsnDamage()
    End Sub

    Private Sub poisonResM75_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles poisonResM75.CheckedChanged
        psnRes = 1.75
        computePsnDamage()
    End Sub

    Private Sub poisonRes0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles poisonRes0.CheckedChanged
        psnRes = 1
        computePsnDamage()
    End Sub

    Private Sub poisonRes25_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles poisonRes25.CheckedChanged
        psnRes = 0.75
        computePsnDamage()
    End Sub

    Private Sub poisonRes50_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles poisonRes50.CheckedChanged
        psnRes = 0.5
        computePsnDamage()
    End Sub

    Private Sub poisonRes75_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles poisonRes75.CheckedChanged
        psnRes = 0.25
        computePsnDamage()
    End Sub

    Private Sub poisonImmune_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles poisonImmune.CheckedChanged
        psnRes = 0
        computePsnDamage()
    End Sub

    Private Sub computePsnDamage()
        If psnAmt = 0 Then
            psnDmg = 0
        ElseIf psnAmt = 1 Then
            psnDmg = 0
        ElseIf psnAmt = 2 Then
            psnDmg = 0
        ElseIf psnAmt = 3 Then
            psnDmg = 10 * psnRes
        ElseIf psnAmt = 4 Then
            psnDmg = 17 * psnRes
        ElseIf psnAmt = 5 Then
            psnDmg = 25 * psnRes
        ElseIf psnAmt = 6 Then
            psnDmg = 35 * psnRes
        ElseIf psnAmt = 7 Then
            psnDmg = 50 * psnRes
        ElseIf psnAmt = 8 Then
            psnDmg = 82 * psnRes
        ElseIf psnAmt = 9 Then
            psnDmg = 95 * psnRes
        ElseIf psnAmt = 10 Then
            psnDmg = 115 * psnRes
        End If
        poisonDamageDisplay.Text = psnDmg
    End Sub

    Private Sub bleedResM25_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bleedResM25.CheckedChanged
        bleRes = 1.25
        computeBleDamage()
    End Sub

    Private Sub bleedResM50_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bleedResM50.CheckedChanged
        bleRes = 1.5
        computeBleDamage()
    End Sub

    Private Sub bleedResM75_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bleedResM75.CheckedChanged
        bleRes = 1.75
        computeBleDamage()
    End Sub

    Private Sub bleedRes0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bleedRes0.CheckedChanged
        bleRes = 1
        computeBleDamage()
    End Sub

    Private Sub bleedRes25_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bleedRes25.CheckedChanged
        bleRes = 0.75
        computeBleDamage()
    End Sub

    Private Sub bleedRes50_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bleedRes50.CheckedChanged
        bleRes = 0.5
        computeBleDamage()
    End Sub

    Private Sub bleedRes75_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bleedRes75.CheckedChanged
        bleRes = 0.25
        computeBleDamage()
    End Sub

    Private Sub bleedImmune_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bleedImmune.CheckedChanged
        bleRes = 0
        computeBleDamage()
    End Sub

    Private Sub computeBleDamage()
        If bleAmt = 0 Then
            bleDmg = 0
        Else
            bleDmg = (bleAmt ^ 2.24) * bleRes
        End If
        bleedDamageDisplay.Text = bleDmg
    End Sub

    Private Sub pureResM25_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pureResM25.CheckedChanged
        purRes = 1.25
        computePurDamage()
    End Sub

    Private Sub pureResM50_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pureResM50.CheckedChanged
        purRes = 1.5
        computePurDamage()
    End Sub

    Private Sub pureResM75_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pureResM75.CheckedChanged
        purRes = 1.75
        computePurDamage()
    End Sub

    Private Sub pureRes0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pureRes0.CheckedChanged
        purRes = 1
        computePurDamage()
    End Sub

    Private Sub pureRes25_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pureRes25.CheckedChanged
        purRes = 0.75
        computePurDamage()
    End Sub

    Private Sub pureRes50_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pureRes50.CheckedChanged
        purRes = 0.5
        computePurDamage()
    End Sub

    Private Sub pureRes75_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pureRes75.CheckedChanged
        purRes = 0.25
        computePurDamage()
    End Sub

    Private Sub pureImmune_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pureImmune.CheckedChanged
        purRes = 0
        computePurDamage()
    End Sub

    Private Sub computePurDamage()
        purDmg = (purAmt * 15) * purRes
        pureDamageDisplay.Text = purDmg
    End Sub

    Private Sub frenzyResM75_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frenzyResM75.CheckedChanged
        freRes = 1.75
        computeFrenzyDamage()
    End Sub

    Private Sub frenzyResM50_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frenzyResM50.CheckedChanged
        freRes = 1.5
        computeFrenzyDamage()
    End Sub

    Private Sub frenzyResM25_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frenzyResM25.CheckedChanged
        freRes = 1.25
        computeFrenzyDamage()
    End Sub

    Private Sub frenzyRes0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frenzyRes0.CheckedChanged
        freRes = 1
        computeFrenzyDamage()
    End Sub

    Private Sub frenzyRes25_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frenzyRes25.CheckedChanged
        freRes = 0.75
        computeFrenzyDamage()
    End Sub

    Private Sub frenzyRes50_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frenzyRes50.CheckedChanged
        freRes = 0.5
        computeFrenzyDamage()
    End Sub

    Private Sub frenzyRes75_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frenzyRes75.CheckedChanged
        freRes = 0.25
        computeFrenzyDamage()
    End Sub

    Private Sub frenzyImmune_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frenzyImmune.CheckedChanged
        freRes = 0
        computeFrenzyDamage()
    End Sub

    Private Sub computeFrenzyDamage()
        If freAmt = 0 Then
            freInfluence = 0
            frenzyBuild.Text = 0
        ElseIf freAmt = 1 Then
            freInfluence = 1.03
            frenzyBuild.Text = 0
        ElseIf freAmt = 2 Then
            freInfluence = 1.05
            frenzyBuild.Text = 0
        ElseIf freAmt = 3 Then
            freInfluence = 1.08
            frenzyBuild.Text = 1
        ElseIf freAmt = 4 Then
            freInfluence = 1.11
            frenzyBuild.Text = 1
        ElseIf freAmt = 5 Then
            freInfluence = 1.13
            frenzyBuild.Text = 1
        ElseIf freAmt = 6 Then
            freInfluence = 1.15
            frenzyBuild.Text = 2
        ElseIf freAmt = 7 Then
            freInfluence = 1.18
            frenzyBuild.Text = 2
        ElseIf freAmt = 8 Then
            freInfluence = 1.21
            frenzyBuild.Text = 2
        ElseIf freAmt = 9 Then
            freInfluence = 1.23
            frenzyBuild.Text = 2
        ElseIf freAmt = 10 Then
            freInfluence = 1.25
            frenzyBuild.Text = 3
        End If
        frenzyInfluenceTextBox.Text = freInfluence
        If freAmt = 0 Then
            freDmg = 0
        ElseIf freRes = 0.25 Then
            freDmg = ((curAttackDamage ^ freInfluence) / 2) - curAttackDamage
        Else
            freDmg = (curAttackDamage ^ freInfluence) - curAttackDamage
        End If
        If freAmt < 5 Then
            freSelfDmg = 0
        Else
            freSelfDmg = (curAttackDamage ^ (freInfluence / 1.13)) * freRes
        End If
        If freRes = 1.75 Then
            If freAmt >= 1 Then
                plusOrMinus.Text = "+"
            Else
                plusOrMinus.Text = "-"
            End If
        ElseIf freRes = 1.5 Then
            If freAmt >= 2 Then
                plusOrMinus.Text = "+"
            Else
                plusOrMinus.Text = "-"
            End If
        ElseIf freRes = 1 Then
            If freAmt >= 3 Then
                plusOrMinus.Text = "+"
            Else
                plusOrMinus.Text = "-"
            End If
        ElseIf freRes = 0.75 Then
            If freAmt >= 4 Then
                plusOrMinus.Text = "+"
            Else
                plusOrMinus.Text = "-"
            End If
        ElseIf freRes = 0.5 Then
            If freAmt >= 6 Then
                plusOrMinus.Text = "+"
            Else
                plusOrMinus.Text = "-"
            End If
        ElseIf freRes = 0.25 Then
            plusOrMinus.Text = "n/a"
        ElseIf freRes = 0 Then
            freDmg = 0
            freSelfDmg = 0
        End If
        frenzyDamage.Text = freDmg
        frenzyBDamage.Text = freSelfDmg
    End Sub

    Private Sub diamondRes50_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles diamondRes50.CheckedChanged
        diaRes = 0.5
        computeDiaDamage()
    End Sub

    Private Sub diamondRes0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles diamondRes0.CheckedChanged
        diaRes = 1
        computeDiaDamage()
    End Sub

    Private Sub diamondRes99_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles diamondRes99.CheckedChanged
        diaRes = 0.1
        computeDiaDamage()
    End Sub

    Private Sub computeDiaDamage()
        If diaAmt = 0 Then
            diamondBuild.Text = 0
            diamondMovementDefecit.Text = "Unaffected"
        ElseIf diaAmt = 1 Then
            diamondBuild.Text = 10
            diamondMovementDefecit.Text = "Trips when jumping"
        ElseIf diaAmt = 2 Then
            diamondBuild.Text = 10
            diamondMovementDefecit.Text = "Trips when jumping"
        ElseIf diaAmt = 3 Then
            diamondBuild.Text = 25
            diamondMovementDefecit.Text = "Grounded"
        ElseIf diaAmt = 4 Then
            diamondBuild.Text = 25
            diamondMovementDefecit.Text = "Grounded"
        ElseIf diaAmt = 5 Then
            diamondBuild.Text = 25
            diamondMovementDefecit.Text = "Grounded"
        ElseIf diaAmt = 6 Then
            diamondBuild.Text = 50
            diamondMovementDefecit.Text = "Movement is halved"
        ElseIf diaAmt = 7 Then
            diamondBuild.Text = 25
            diamondMovementDefecit.Text = "Movement is halved"
        ElseIf diaAmt = 8 Then
            diamondBuild.Text = 50
            diamondMovementDefecit.Text = "Movement is halved"
        ElseIf diaAmt = 9 Then
            diamondBuild.Text = 25
            diamondMovementDefecit.Text = "Can barely move..."
        ElseIf diaAmt = 10 Then
            diamondBuild.Text = "n/a"
            diamondMovementDefecit.Text = "Diamondized!"
        End If
        If diaRes = 1 Then
            If diaAmt > 0 Then
                diaDmg = 1.588 ^ diaAmt
                diaArm = 1.8 ^ diaAmt
            Else
                diaDmg = 0
                diaArm = 0
            End If
        ElseIf diaRes = 0.5 Then
            If diaAmt > 0 Then
                diaDmg = (1.588 ^ diaAmt) * diaRes
                diaArm = (1.8 ^ diaAmt) * diaRes
            Else
                diaDmg = 0
                diaArm = 0
            End If
        ElseIf diaRes = 0.1 Then
            If diaAmt < 10 Then
                diamondMovementDefecit.Text = "Unaffected"
            ElseIf diaAmt = 10 Then
                diamondMovementDefecit.Text = "Diamondized!"
            End If
            If diaAmt = 9 Then
                diamondBuild.Text = 10
            End If
            If diaAmt > 0 Then
                diaDmg = 1.588 ^ diaAmt
                diaArm = 1.8 ^ diaAmt
            Else
                diaDmg = 0
                diaArm = 0
            End If
        End If
        diamondDamage.Text = diaDmg
        diamondArmorBonus.Text = diaArm
    End Sub

    Private Sub Calculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calculate.Click
        calcAll()
        If undead = False Then
            bonusAttackTextBox.Text = freDmg + diaDmg + curAttackDamage + purDmg
        ElseIf undead = True Then
            bonusAttackTextBox.Text = freDmg + diaDmg + curAttackDamage
        End If
    End Sub

    Private Sub isUndead_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles isUndead.CheckedChanged
        If undead = True Then
            undead = False
        ElseIf undead = False Then
            undead = True
        End If
    End Sub

    Private Sub Damage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Damage.Click
        If dealtDamageText.Text <> "" Then
            dealtDamage = 0
            physicalDamage = 0
            specialDamage = 0
            calcAll()
            updateArmor()
            physicalDamage = dealtDamageText.Text
            If undead = True Then
                physicalDamage = physicalDamage + purDmg
            ElseIf undead = False Then
                physicalDamage = physicalDamage - purDmg
            End If
            If invincible = False Then
                If physicalDamage <= totalArmor Then
                    physicalDamage = 0
                End If
                specialDamage = specialDamage + bleDmg + psnDmg + freSelfDmg
            End If
            dealtDamage = physicalDamage + specialDamage
            curHealth = curHealth - dealtDamage
            currentHealthBox.Text = curHealth
            damageTotalTextBox.Text = dealtDamage
        End If
    End Sub

    Private Sub calcAll()
        computePsnDamage()
        computeBleDamage()
        computePurDamage()
        computeFrenzyDamage()
        computeDiaDamage()
    End Sub

    Private Sub armorCalcButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles armorCalcButton.Click
        computeDiaDamage()
        updateArmor()
    End Sub
    Private Sub updateArmor()
        dexterity = dexBox.Text
        extraArmor = extraArmorBox.Text
        totalArmor = extraArmor + diaArm + dexterity
        If totalArmor <= 357 Then
            ACLabel.Text = totalArmor
        Else
            ACLabel.Text = 357
        End If
    End Sub

    Private Sub invincible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles invincibleCheck.CheckedChanged
        If invincible = True Then
            invincible = False
        ElseIf invincible = False Then
            invincible = True
        End If
    End Sub

    Private Sub healBy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles healBy.Click
        If healAmount.Text <> "" Then
            If (curHealth + healAmount.Text) < maxHealth Then
                curHealth = curHealth + healAmount.Text
            Else
                curHealth = maxHealth
            End If
        End If
        currentHealthBox.Text = curHealth
    End Sub

    Private Sub classTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles classTextBox.TextChanged
        If classTextBox.Text <> "" Then
            If classTextBox.Text = "Priest" Then
                ultBox.Text = "Madman's Omnipotence"
                strBox.BackColor = Color.LightSeaGreen
                wisBox.BackColor = Color.LightSeaGreen
            ElseIf classTextBox.Text = "Pyro" Then
                ultBox.Text = "Black Flame"
                intBox.BackColor = Color.LightSeaGreen
                wisBox.BackColor = Color.LightSeaGreen
            ElseIf classTextBox.Text = "Vamp" Then
                ultBox.Text = "Tear of Aja"
                dexBox.BackColor = Color.LightSeaGreen
                conBox.BackColor = Color.LightSeaGreen
            ElseIf classTextBox.Text = "Reaper" Then
                ultBox.Text = "Guiding Moonlight"
                strBox.BackColor = Color.LightSeaGreen
                dexBox.BackColor = Color.LightSeaGreen
            ElseIf classTextBox.Text = "Undead" Then
                ultBox.Text = "Detachment"
                strBox.BackColor = Color.LightSeaGreen
                conBox.BackColor = Color.LightSeaGreen
            Else
                ultBox.Text = "Undefined"
                strBox.BackColor = SystemColors.Window
                dexBox.BackColor = SystemColors.Window
                conBox.BackColor = SystemColors.Window
                intBox.BackColor = SystemColors.Window
                wisBox.BackColor = SystemColors.Window
            End If
        End If
    End Sub
End Class
