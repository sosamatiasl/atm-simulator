# atm-simulator
Simulador de Cajero Automático (ATM)

🏧 Manual del Usuario: Simulador de Cajero Automático (ATM)
Este manual le guiará a través del uso de la aplicación de escritorio del Simulador de Cajero Automático, desde el inicio de sesión hasta la realización de transacciones financieras.

1. 🔑 Pantalla de Inicio de Sesión
   Al iniciar la aplicación, se le pedirá que ingrese sus credenciales para acceder a sus cuentas.
   Ingrese el número completo de 16 dígitos de su cuenta bancaria.
   Ingrese su Clave de Identificación Personal (PIN) de 4 dígitos.
   Haga clic en el botón "Ingresar" para validar sus credenciales.

   Si las credenciales son correctas, la ventana de Login se cerrará y se abrirá la Ventana Principal de Operaciones.
   Si las credenciales son incorrectas, aparecerá un mensaje de error en rojo debajo del botón ("Credenciales incorrectas...").

2. 🖥️ Ventana Principal de Operaciones
   Una vez iniciada la sesión, verá la información de su cuenta y las opciones de transacción.

   2.1. Información de la Cuenta
   En la parte superior de la ventana se muestra su información clave:
   Número de Cuenta: El número de 16 dígitos con el que está operando.
   Saldo Actual: El saldo disponible en su cuenta en tiempo real.

   2.2. Realizar Transacciones
   Para realizar cualquier transacción (Retirar o Depositar), debe ingresar el monto deseado en el campo de texto antes de presionar el botón de la operación.
   Ingrese el monto (ej: 100.00).
   Botón "Retirar" realiza una retirada de efectivo de su saldo. La aplicación verificará si tiene saldo suficiente.
   Botón "Depositar" realiza un ingreso de fondos a su saldo. El monto se sumará inmediatamente a su saldo.
   Botón "Consultar Saldo" muestra el saldo actual en el mensaje de operación. Haga clic para refrescar la información y recibir el saldo como mensaje de confirmación.

   2.3. Mensaje de Operación
   Tras cada intento de transacción, el sistema mostrará un mensaje de confirmación o error en la parte inferior de la ventana, indicando el resultado.
   Ejemplo de Éxito (Retiro): "Retiro de $100.00 exitoso. Saldo actual: $X,XXX.XX."
   Ejemplo de Error (Retiro): "Saldo insuficiente para realizar esta transacción."
 
3. 🚪 Cerrar la Sesión
   Para salir de la aplicación, simplemente cierre la ventana principal de operaciones.
   Por seguridad, no hay un botón de "Cerrar Sesión" ya que, en un ATM real, la sesión termina al retirar la tarjeta.
   Al cerrar la ventana, la aplicación se detendrá.

Nota Importante: Este simulador interactúa con una base de datos SQL Server, por lo que todos los cambios de saldo (depósitos y retiros) son permanentes.
