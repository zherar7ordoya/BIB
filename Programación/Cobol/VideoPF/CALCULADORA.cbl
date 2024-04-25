       IDENTIFICATION DIVISION.
       PROGRAM-ID.  CALCULADORA.

       DATA DIVISION.
       WORKING-STORAGE SECTION.
       01 NUMERO-1            PIC 9(5).
       01 NUMERO-2            PIC 9(5).
       01 OPERACION           PIC X.

       PROCEDURE DIVISION.
       INICIO.
           DISPLAY "Ingrese el primer número: ".
           ACCEPT NUMERO-1.
           DISPLAY "Ingrese el segundo número: ".
           ACCEPT NUMERO-2.
           DISPLAY "Ingrese la operación (+, -, *, /): ".
           ACCEPT OPERACION.

           IF OPERACION = "+" THEN
               PERFORM SUMAR
           ELSE IF OPERACION = "-" THEN
               PERFORM RESTAR
           ELSE IF OPERACION = "*" THEN
               PERFORM MULTIPLICAR
           ELSE IF OPERACION = "/" THEN
               PERFORM DIVIDIR
           ELSE
               DISPLAY "Operación no válida"
           END-IF.

           STOP RUN.

       SUMAR.
           COMPUTE NUMERO-1 = NUMERO-1 + NUMERO-2.
           DISPLAY "El resultado de la suma es: " NUMERO-1.

       RESTAR.
           COMPUTE NUMERO-1 = NUMERO-1 - NUMERO-2.
           DISPLAY "El resultado de la resta es: " NUMERO-1.

       MULTIPLICAR.
           COMPUTE NUMERO-1 = NUMERO-1 * NUMERO-2.
           DISPLAY "El resultado de la multiplicación es: " NUMERO-1.

       DIVIDIR.
           IF NUMERO-2 = 0 THEN
               DISPLAY "No se puede dividir entre cero"
           ELSE
               COMPUTE NUMERO-1 = NUMERO-1 / NUMERO-2
               DISPLAY "El resultado de la división es: " NUMERO-1
           END-IF.
