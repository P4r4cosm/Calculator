# main.py

import tkinter as tk
from tkinter import messagebox
from calculator_logic import do_operation, do_function, Operation, Function
import math

class CalculatorApp(tk.Tk):
    def __init__(self):
        super().__init__()
        self.title("Calculator (tkinter)")

        # Основные переменные, которые были в форме
        self.result = 0.0
        self.current_number = 0.0
        self.current_operation = None
        self.memory_value = 0.0

        # Виджет для вывода результата (аналог Label Input.Text = "0")
        self.input_var = tk.StringVar(value="0")
        self.input_entry = tk.Entry(self, textvariable=self.input_var, font=("Arial", 20), width=18, bd=5, justify="right")
        self.input_entry.grid(row=0, column=0, columnspan=4, padx=5, pady=5)

        # Метка для отображения памяти (Memo)
        self.memo_var = tk.StringVar(value="0")
        self.memo_label = tk.Label(self, text="Memo:", font=("Arial", 12))
        self.memo_label.grid(row=1, column=0, sticky="e")
        self.memo_value_label = tk.Label(self, textvariable=self.memo_var, font=("Arial", 12))
        self.memo_value_label.grid(row=1, column=1, sticky="w")

        # Трекбар (Scale) для округления
        # min=0 (Floor), pos=1 (WithoutRound), max=2 (Ceil)
        self.round_scale = tk.Scale(self, from_=0, to=2, orient=tk.HORIZONTAL, label="Rounding Mode")
        self.round_scale.set(1)  # по умолчанию WithoutRound
        self.round_scale.grid(row=2, column=0, columnspan=4, sticky="we", padx=5)

        # Далее создаём кнопки. Для упрощения делаем несколько кнопок в одной строке
        # В реальном приложении стоит разбивать более красиво

        # Первая строка (MC, MS, M-, M+)
        tk.Button(self, text="MC", command=self.memory_clear).grid(row=3, column=0, sticky="we")
        tk.Button(self, text="MS", command=self.memory_save).grid(row=3, column=1, sticky="we")
        tk.Button(self, text="M-", command=self.memory_sub).grid(row=3, column=2, sticky="we")
        tk.Button(self, text="M+", command=self.memory_add).grid(row=3, column=3, sticky="we")

        # Вторая строка (sqrt, ^, sin, cos)
        tk.Button(self, text="√",  command=self.button_sqrt).grid(row=4, column=0, sticky="we")
        tk.Button(self, text="^",  command=self.button_raise).grid(row=4, column=1, sticky="we")
        tk.Button(self, text="sin",command=self.button_sin).grid(row=4, column=2, sticky="we")
        tk.Button(self, text="cos",command=self.button_cos).grid(row=4, column=3, sticky="we")

        # Третья строка (7, 8, 9, /)
        tk.Button(self, text="7", command=lambda: self.number_click("7")).grid(row=5, column=0, sticky="we")
        tk.Button(self, text="8", command=lambda: self.number_click("8")).grid(row=5, column=1, sticky="we")
        tk.Button(self, text="9", command=lambda: self.number_click("9")).grid(row=5, column=2, sticky="we")
        tk.Button(self, text="÷", command=lambda: self.set_operation(Operation.DIVIDE)).grid(row=5, column=3, sticky="we")

        # Четвертая строка (4, 5, 6, x)
        tk.Button(self, text="4", command=lambda: self.number_click("4")).grid(row=6, column=0, sticky="we")
        tk.Button(self, text="5", command=lambda: self.number_click("5")).grid(row=6, column=1, sticky="we")
        tk.Button(self, text="6", command=lambda: self.number_click("6")).grid(row=6, column=2, sticky="we")
        tk.Button(self, text="×", command=lambda: self.set_operation(Operation.MULTIPLY)).grid(row=6, column=3, sticky="we")

        # Пятая строка (1, 2, 3, -)
        tk.Button(self, text="1", command=lambda: self.number_click("1")).grid(row=7, column=0, sticky="we")
        tk.Button(self, text="2", command=lambda: self.number_click("2")).grid(row=7, column=1, sticky="we")
        tk.Button(self, text="3", command=lambda: self.number_click("3")).grid(row=7, column=2, sticky="we")
        tk.Button(self, text="-", command=lambda: self.set_operation(Operation.SUBTRACT)).grid(row=7, column=3, sticky="we")

        # Шестая строка (0, 00, ., +)
        tk.Button(self, text="0", command=lambda: self.number_click("0")).grid(row=8, column=0, sticky="we")
        tk.Button(self, text="00", command=lambda: self.number_click("00")).grid(row=8, column=1, sticky="we")
        tk.Button(self, text=".", command=lambda: self.number_click(".")).grid(row=8, column=2, sticky="we")
        tk.Button(self, text="+", command=lambda: self.set_operation(Operation.ADD)).grid(row=8, column=3, sticky="we")

        # Седьмая строка (%, +/-, C, =)
        tk.Button(self, text="%", command=lambda: self.set_operation(Operation.MODULO)).grid(row=9, column=0, sticky="we")
        tk.Button(self, text="+/-", command=self.invert_number).grid(row=9, column=1, sticky="we")
        tk.Button(self, text="C", command=self.clear_input).grid(row=9, column=2, sticky="we")
        tk.Button(self, text="=", bg="lightblue", command=self.calculate_result).grid(row=9, column=3, sticky="we")

    # ----------------------- Методы «памяти» -----------------------
    def memory_clear(self):
        self.memory_value = 0.0
        self.memo_var.set(str(self.memory_value))

    def memory_save(self):
        val = self._get_input_value()
        if val is not None:
            self.memory_value = val
            self.memo_var.set(str(self.memory_value))
        else:
            messagebox.showerror("Error", "Invalid input. Unable to save to memory.")

    def memory_add(self):
        val = self._get_input_value()
        if val is not None:
            self.memory_value += val
            self.memo_var.set(str(self.memory_value))
        else:
            messagebox.showerror("Error", "Invalid input for M+.")

    def memory_sub(self):
        val = self._get_input_value()
        if val is not None:
            self.memory_value -= val
            self.memo_var.set(str(self.memory_value))
        else:
            messagebox.showerror("Error", "Invalid input for M-.")

    # ----------------------- Методы операций / функций -----------------------
    def button_sqrt(self):
        current = self._get_input_value()
        if current is not None:
            # Выполняем sqrt + округление
            res = do_function(current, Function.SQRT)
            res = self._apply_rounding(res)
            self.input_var.set(str(res))

    def button_sin(self):
        current = self._get_input_value()
        if current is not None:
            res = do_function(current, Function.SIN)
            res = self._apply_rounding(res)
            self.input_var.set(str(res))

    def button_cos(self):
        current = self._get_input_value()
        if current is not None:
            res = do_function(current, Function.COS)
            res = self._apply_rounding(res)
            self.input_var.set(str(res))

    def button_raise(self):
        # Устанавливаем операцию "возведение в степень"
        self.set_operation(Operation.POWER)

    # ----------------------- Установка операции ( + - × ÷ ^ % ) -----------------------
    def set_operation(self, op: Operation):
        val = self._get_input_value()
        if val is not None:
            self.current_operation = op
            self.current_number = val
            self.input_var.set("0")

    # ----------------------- Ввод цифр -----------------------
    def number_click(self, num_str: str):
        current_text = self.input_var.get()
        # Аналог: if Input.Text == "0" => Input.Text = ...
        if current_text == "0":
            self.input_var.set(num_str)
        else:
            # Вставляем десятичную точку, если её ещё нет
            if num_str in ["."] and "." in current_text:
                return  # уже есть точка, не даём вставить вторую
            self.input_var.set(current_text + num_str)

    # ----------------------- Кнопка +/- -----------------------
    def invert_number(self):
        current = self._get_input_value()
        if current is not None:
            self.input_var.set(str(-current))
        else:
            messagebox.showerror("Error", "Invalid input")

    # ----------------------- Кнопка "C" (Clear) -----------------------
    def clear_input(self):
        self.input_var.set("0")

    # ----------------------- Кнопка "=" -----------------------
    def calculate_result(self):
        second_value = self._get_input_value()
        if second_value is not None and self.current_operation is not None:
            raw_result = do_operation(self.current_number, second_value, self.current_operation)
            # Применим ещё «функцию» округления (Floor / Ceil / WithoutRound)
            final_result = self._apply_rounding(raw_result)
            self.input_var.set(str(final_result))
            # Запоминаем новый result/currNumber
            self.result = final_result
            self.current_number = final_result

    # ----------------------- Служебные методы -----------------------
    def _get_input_value(self):
        """Пытается сконвертировать текущее значение на экране в float."""
        try:
            return float(self.input_var.get())
        except ValueError:
            return None

    def _apply_rounding(self, val: float) -> float:
        """Смотрим, какое положение у Scale (0=Floor,1=NoRound,2=Ceil)
           и применяем функцию из calculator_logic."""
        mode = self.round_scale.get()
        if mode == 0:
            return math.floor(val)
        elif mode == 1:
            return val  # без округления
        elif mode == 2:
            return math.ceil(val)
        return val

def main():
    app = CalculatorApp()
    app.mainloop()

if __name__ == "__main__":
    main()
