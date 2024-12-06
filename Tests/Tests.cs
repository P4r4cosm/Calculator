﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System.Windows.Forms;
using System.Reflection;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestAllDoOperations()
        {
            double addition = Calculator1.DoOperation(5, 3, Calculator1.Operation.Add);
            double subtraction = Calculator1.DoOperation(5, 3, Calculator1.Operation.Subtract);
            double multiplication = Calculator1.DoOperation(5, 3, Calculator1.Operation.Multiply);
            double division = Calculator1.DoOperation(6, 3, Calculator1.Operation.Divide);
            double power = Calculator1.DoOperation(2, 3, Calculator1.Operation.Power);
            double modulo = Calculator1.DoOperation(5, 3, Calculator1.Operation.Modulo);

            Assert.AreEqual(8, addition, "Операция сложения не выполнена.");
            Assert.AreEqual(2, subtraction, "Операция вычитания не выполнена.");
            Assert.AreEqual(15, multiplication, "Операция умножения не выполнена.");
            Assert.AreEqual(2, division, "Операция деления не выполнена.");
            Assert.AreEqual(8, power, "Операция возведения в степень не выполнена.");
            Assert.AreEqual(2, modulo, "Операция взятия остатка не выполнена.");
        }

        [TestMethod]
        public void TestForm1ButtonClick()
        {
            var form = new Form1();
            var button = new System.Windows.Forms.Button { Text = "7" };

            form.Controls.Add(button);

            form.Controls["Input"].Text = "0";

            var buttonClickMethod = form.GetType().GetMethod("button_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            buttonClickMethod.Invoke(form, new object[] { button, EventArgs.Empty });

            Assert.AreEqual("7", form.Controls["Input"].Text, "Нажатие кнопки не обновило Input корректно.");
        }

        [TestMethod]
        public void TestForm1SolveOperation()
        {
            var form = new Form1();
            Button someButton = new Button();
            form.Controls["Input"].Text = "5";
            form.GetType().GetField("currentNumber", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(form, 3);
            form.GetType().GetField("currentOperation", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(form, Calculator1.Operation.Add);

            var buttonSolveMethod = form.GetType().GetMethod("button_solve_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            buttonSolveMethod.Invoke(form, new object[] { someButton, EventArgs.Empty });

            Assert.AreEqual("8", form.Controls["Input"].Text, "Операция вычисления не выполнена.");
        }

        [TestMethod]
        public void TestMemorySave()
        {
            var form = new Form1();
            form.Controls["Input"].Text = "10";

            var buttonSave = new System.Windows.Forms.Button();
            form.GetType().GetMethod("button_msave_Click", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(form, new object[] { buttonSave, EventArgs.Empty });

            Assert.AreEqual("10", form.Controls["memoNum"].Text, "Функция сохранения в память не выполнена.");
        }

        [TestMethod]
        public void TestMemoryClear()
        {
            var form = new Form1();
            form.Controls["Input"].Text = "15";

            var buttonSave = new System.Windows.Forms.Button();
            form.GetType().GetMethod("button_msave_Click", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(form, new object[] { buttonSave, EventArgs.Empty });

            var buttonClear = new System.Windows.Forms.Button();
            form.GetType().GetMethod("button_mclear_Click", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(form, new object[] { buttonClear, EventArgs.Empty });

            Assert.AreEqual("0", form.Controls["memoNum"].Text, "Функция очистки памяти не выполнена.");
        }


    }
}
