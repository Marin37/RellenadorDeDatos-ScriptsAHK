# RellenadorDeDatos-ScriptsAHK
Un pequeño programa que crea scripts para cargar datos de prueba por consola o terminal. Útil para probar datos con programas básicos, en mi caso lo utilizo principalmente para la escuela. 
  
¿Alguna vez tuviste que testear un código que utilice datos introducidos del usuaro para guardar en algún array o matriz, etc? ¿Resulta tedioso tener que cargar todos los datos cada vez que quieres probar el código? Esta simple herramienta toma el input que le cargues y construye un script para introducir todos esos datos (con Enter incluido) de forma automatizada simplemente con el presionar de una tecla.
  
_No es un nombre muy original, lo admito..._

<br><br>



## Instrucciones de uso APB

1. Usar el ejecutable "[Programa\bin\Debug\Creador-de-relleno.exe](https://github.com/Marin37/RellenadorDeDatos-ScriptsAHK/blob/main/Programa/bin/Debug/Creador-de-relleno.exe)" o bien abrir la solución (con Visual Studio) "[Programa\Creador-de-relleno.sln](https://github.com/Marin37/RellenadorDeDatos-ScriptsAHK/blob/main/Programa/Creador-de-relleno.sln)" o 

2. Introducir parámetros requeridos al inicio, hacer click en el botón "Cargar Datos" e ingresar los datos que quiera que se escriban automáticamente. Para terminar de cargar, ingrese el valor de cierre que declaró (el mismo valor está por defecto)

3. **[EN PROCESO]** Para borrar o insertar seleccione un ítem en la lista y presione el botón correspondiente. Si desea cancelar, cargue los valores por defecto de los parámetros y luego use el botón "Cancelar" o cierre el formulario (también se puede usar ESCape).

4. Instalar el programa [AutoHotKey](https://www.autohotkey.com/)
_(puede ser desde "AutoHotkey_1.1.33.10_setup.exe" descargado oficialmente de https://www.autohotkey.com/). La "Instalación Express" es suficiente._

5. Ejecutar el script terminado en ".ahk" 

6. Apretar la tecla asignada y Voalá

7. Si terminó de usar el script ".ahk", deberá luego cerrarlo desde el menú abajo a la derecha de la barra de tareas. Allí aparecerá un ícono verde con una [H] > Click derecho > "Salir" o "Exit". Tenga en cuenta que si nunca lo cierra se podrá activar inesperadamente si apreta la tecla designada.

<br>

## Parámetros requeridos

- **Tiempo** - Es el tiempo en milisegundos que va a esperar el script antes de escribir el siguiente registro y presionar {Enter}. Mientras menor sea más rápido se ejecutará, pero si quiere verificarlo puede usar un tiempo más alto.

- **Tecla** - La tecla mágica que asignada al script, será la que se utiliza para cargar todos los datos al ser presionada. Se recomienda asignar una tecla que no se use con frecuencia (por defecto F7). Recuerde cerrar el script desde la barra de tareas una vez finalizado.

- **Nombre** - Es el nombre del archivo que se va a utilizar, se solicita solo el nombre específico del ejercicio. Por ejemplo si guarda "Matrices2", el archivo final será "F7-Matrices2.ahk"

- **VCierre**- El valor con el que quiere que termine el programa, ejemplos son 0, "X", "-1", entre otros. Al cargar este valor decide si quiere guardado al final o no. Por ejemplo si está testeando corte de control resulta conveniente dejarlo y al finalizar automáticamente se enviará el valor de cierre, pero si quiere agregar datos o el programa a testear corta automáticamente no es necesario.

<br>

## To Do

- Agregar borrar e insertar
- Reestructurar para solo crear archvo al final
