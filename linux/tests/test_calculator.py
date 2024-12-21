# tests/test_calculator.py

import unittest
import math
from calculator_logic import do_operation, do_function, Operation, Function
from main import CalculatorApp  # если хотим тестировать некоторые методы из GUI

class TestCalculatorLogic(unittest.TestCase):
    def test_do_operation(self):
        self.assertEqual(do_operation(5, 3, Operation.ADD), 8,    "Сложение не выполнено.")
        self.assertEqual(do_operation(5, 3, Operation.SUBTRACT), 2, "Вычитание не выполнено.")
        self.assertEqual(do_operation(5, 3, Operation.MULTIPLY), 15,"Умножение не выполнено.")
        self.assertEqual(do_operation(6, 3, Operation.DIVIDE),   2, "Деление не выполнено.")
        self.assertEqual(do_operation(2, 3, Operation.POWER),    8, "Возведение в степень не выполнено.")
        self.assertEqual(do_operation(5, 3, Operation.MODULO),   2, "Операция Modulo не выполнена.")

    def test_do_function(self):
        # sin(pi/2) = 1
        self.assertAlmostEqual(do_function(math.pi / 2, Function.SIN), 1, delta=0.0001)
        # cos(0) = 1
        self.assertAlmostEqual(do_function(0, Function.COS), 1, delta=0.0001)
        # sqrt(16) = 4
        self.assertEqual(do_function(16, Function.SQRT), 4)
        # floor(5.7) = 5
        self.assertEqual(do_function(5.7, Function.FLOOR), 5)
        # ceil(5.3) = 6
        self.assertEqual(do_function(5.3, Function.CEIL), 6)
        # without round(3.14159) = 3.14159
        self.assertEqual(do_function(3.14159, Function.WITHOUT_ROUND), 3.14159)

class TestCalculatorGUI(unittest.TestCase):
    def setUp(self):
        # Перед каждым тестом создаём инстанс приложения
        self.app = CalculatorApp()
        # Чтобы не открывалось реальное окно, иногда делают self.app.withdraw()
        # но тогда при вызове некоторых tkinter-методов может быть ошибка.
        # Для тестов логических методов внутри GUI можно использовать напрямую.

    def tearDown(self):
        # После теста закрываем окно
        self.app.destroy()

    def test_memory_save_and_clear(self):
        self.app.input_var.set("10")
        self.app.memory_save()  # аналог button_msave_Click
        self.assertEqual(self.app.memo_var.get(), "10.0", "MS не сохранил значение.")

        self.app.memory_clear() # аналог button_mclear_Click
        self.assertEqual(self.app.memo_var.get(), "0.0", "MC не очистил значение.")

    def test_memory_add(self):
        self.app.input_var.set("10")
        self.app.memory_save()  # MS => memory_value=10
        self.app.input_var.set("5")
        self.app.memory_add()   # M+ => memory_value=15
        self.assertEqual(self.app.memo_var.get(), "15.0", "M+ не сработал.")

    def test_memory_sub(self):
        self.app.input_var.set("20")
        self.app.memory_save()  # MS => memory_value=20
        self.app.input_var.set("8")
        self.app.memory_sub()   # M- => memory_value=12
        self.assertEqual(self.app.memo_var.get(), "12.0", "M- не сработал.")

    def test_clear_input(self):
        self.app.input_var.set("123.45")
        self.app.clear_input()  # аналог button_c_onclick
        self.assertEqual(self.app.input_var.get(), "0", "Очистка поля ввода не сработала.")

    def test_calculate_result_add(self):
        # Проверка операции сложения
        self.app.input_var.set("3")
        self.app.set_operation(Operation.ADD)
        self.app.input_var.set("5")
        self.app.calculate_result()
        self.assertEqual(self.app.input_var.get(), "8.0")

    def test_invert_number(self):
        self.app.input_var.set("10")
        self.app.invert_number()
        self.assertEqual(self.app.input_var.get(), "-10.0")

        self.app.invert_number()
        self.assertEqual(self.app.input_var.get(), "10.0")

    def test_rounding_floor_ceil(self):
        # Выставляем floor
        self.app.round_scale.set(0)  # floor
        self.app.input_var.set("5.7")
        self.app.button_sqrt() # sqrt(5.7) ≈ 2.387...
        # floor(2.387...) = 2
        self.assertEqual(self.app.input_var.get(), "2", "floor не сработал.")

        # Выставляем ceil
        self.app.round_scale.set(2)  # ceil
        self.app.input_var.set("5.7")
        self.app.button_sqrt() # sqrt(5.7) ≈ 2.387...
        # ceil(2.387...) = 3
        self.assertEqual(self.app.input_var.get(), "3", "ceil не сработал.")


if __name__ == "__main__":
    unittest.main()
