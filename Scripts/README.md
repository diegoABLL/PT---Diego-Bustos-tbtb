# Diagrama

![image](https://github.com/user-attachments/assets/bb7bb86a-c373-470b-af49-9a79da7a94a9)

La relación entre estas tablas se organiza para reflejar tanto asociaciones uno a muchos como muchos a muchos.

La relación uno a muchos se establece entre las tablas Desarrolladora y Juegos. En este caso, una desarrolladora puede tener varios juegos asociados a ella. Sin embargo, cada Juego está vinculado a una sola Desarrolladora. Siendo así que un único identificador de Desarrolladora puede corresponder a múltiples registros en la tabla Juegos.

Por otro lado, la relación muchos a muchos se gestiona mediante la tabla intermedia Genero_Juegos. Esta tabla facilita la asociación entre Juegos y Genero. Un Juego puede estar clasificado en varios Géneros, y un Género puede incluir varios Juegos.

Esta tabla intermedia permite representar y gestionar las múltiples relaciones entre los juegos y sus géneros correspondientes.

