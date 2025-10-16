# 💼 Gestión de Gastos

Sistema para gestionar los pagos de los distintos equipos de una empresa.

## 🧩 Descripción
Cada usuario pertenece a un equipo y puede registrar **pagos únicos o recurrentes**, asociados a un tipo de gasto y método de pago.

## 🔹 Entidades principales
- **Equipo:** ID autoincremental y nombre.  
- **Usuario:** nombre, apellido, contraseña (mínimo 8 caracteres), email autogenerado y fecha de ingreso.  
- **Pago:** puede ser único o recurrente, con tipo de gasto, método de pago y descripción.  
- **Métodos de pago:** crédito, débito y efectivo.

## 💰 Beneficios y recargos
- **Pagos únicos:** descuento del 10%, o 20% si es en efectivo.  
- **Pagos recurrentes:** recargo del 3% a 10% según cantidad de cuotas.

## 📅 Funcionalidades
- Registrar pagos.  
- Listar gastos del mes actual.  
- Calcular montos totales con descuentos o recargos aplicados.
