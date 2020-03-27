#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql/mysql.h>

int main(int argc, char *argv[])
{
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	//inicializar la conexion
	conn = mysql_real_connect(conn, "localhost", "root", "mysql", "BBDD",0, NULL, 0);
	if (conn==NULL) {
		printf("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit(1);
	}

//---------------------------------------------------------------------------------

	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];
	char respuesta[512];
	int terminar=0;
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));//inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina.
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(9060);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf("Error al bind");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	int i=1;
	// bucle infinito
	while (i==1)
	{
		
		printf("Escuchando\n");

		sock_conn = accept(sock_listen, NULL, NULL);
		printf("He recibido conexion\n");
		terminar = 0;
		while(terminar==0)
		{
		//sock_conn es el socket que usaremos para este cliente
			// Ahora recibimos la peticiÃ³n
		ret=read(sock_conn,peticion, sizeof(peticion));
			printf("Recibido\n");
			
			// Tenemos que aÃ±adirle la marca de fin de string 
			// para que no escriba lo que hay despues en el buffer
			peticion[ret]='\0';			
			printf("Peticion: %s\n",peticion);
			
			char *p = strtok(peticion, "/");
			int codigo = atoi(p);
			char nombre[30];
			char contrasena[30];
			if (codigo == 0)
			{
				terminar = 1;
				strcpy(respuesta, "DESCONECTA");
				printf("Conexión terminada.");
			}
			
			if (codigo==1) //Registrarse 	1/Nombre/Contraseña
			{
				int igual=0;
				p = strtok(NULL,"/");
				strcpy(nombre,p);
				char consulta [500];
				
				strcpy(consulta, "SELECT nombre FROM Jugador WHERE Jugador.nombre = '");
				strcat(consulta, nombre);
				strcat(consulta, "';");
				
				err=mysql_query(conn, consulta);
				if (err != 0)
				{
					sprintf(respuesta, "ERROR");
				}
				else
				{
					resultado = mysql_store_result(conn);
					row = mysql_fetch_row(resultado);
					
					if (row == NULL)
					{
						p = strtok(NULL, "/");
						strcpy(contrasena,p);
						
						
						err=mysql_query(conn, "SELECT COUNT(*) FROM Jugador;");
						resultado = mysql_store_result(conn);
						row = mysql_fetch_row(resultado);
						
						
						char consulta[500];
						
						strcpy(consulta, "INSERT INTO Jugador VALUES(");
						strcat(consulta, row[0]);
						strcat(consulta, ",'");
						strcat(consulta, nombre);
						strcat(consulta, "','");
						strcat(consulta, contrasena);
						strcat(consulta, "',0);");
						
						err=mysql_query(conn, consulta);
						
						
						sprintf(respuesta, "REGISTRADO OK");
					}
					
					else
					{
						sprintf(respuesta,"NOMBRE EN USO");
					}
				}
			}
			
			else if (codigo==2) //Loguearse		2/Nombre/Contraseña
			{
				p = strtok(NULL, "/");
				strcpy(nombre,p);
				
				p = strtok(NULL,"/");
				strcpy(contrasena,p);
				char consulta[500];
				
				strcpy(consulta, "SELECT * FROM Jugador WHERE Jugador.nombre = '");
				strcat(consulta,nombre);
				strcat(consulta, "' AND Jugador.contraseña = '");
				strcat(consulta, contrasena);
				strcat(consulta, "';");
				
				
				err=mysql_query(conn, consulta);
				resultado = mysql_store_result(conn);
				row = mysql_fetch_row(resultado);
				
				if(row==NULL)
				{
					sprintf(respuesta, "NO ENTRA");
				}
				else{
				   sprintf(respuesta, "ENTRA");
					printf("%s conectado.", nombre);
				}
			}
			
			else if (codigo==3)	//Numero de partidas ganadas por un jugador	3/Nombre
			{
				p=strtok(NULL,"/");
				strcpy(nombre,p);
				char consulta [500];
				
				strcpy(consulta,"SELECT COUNT(nombreganador) FROM Partida WHERE nombreganador = '"); 
				strcat(consulta, nombre);
				strcat(consulta,"';");
				// hacemos la consulta 
				err=mysql_query(conn, consulta); 
				if (err!=0) {
					sprintf(respuesta,"ERROR");
				}
				else
				{
					resultado = mysql_store_result(conn); 
					row = mysql_fetch_row(resultado);
					if (row == NULL)
						sprintf(respuesta,"NO EXISTE");
					else
					{
						int result = atoi(row[0]);
						sprintf(respuesta,"%d",result);
					}
				}
			}
			
			else if (codigo==4)	//Nombre del ganador de una partida en concreto		4/idPartida
			{
				char idPartida [20];
				p=strtok(NULL,"/");
				strcpy(idPartida,p);
				char consulta [500];
				
				strcpy(consulta,"SELECT Jugador.nombre FROM Jugador, Partida WHERE Partida.id="); 
				strcat(consulta, idPartida);
				strcat(consulta," AND Jugador.nombre=Partida.nombreganador;"); 
				err=mysql_query(conn, consulta); 
				if (err!=0) {
					sprintf(respuesta,"ERROR");
				}
				else
				{
				resultado = mysql_store_result(conn); 
				row = mysql_fetch_row(resultado);
				if (row == NULL)
					sprintf(respuesta,"NO EXISTE");
				else
					sprintf(respuesta,"%s",row[0]);
				}
			}
			
			else				//Numero de goles de un jugador		5/Nombre
			{
				int golesresultado;
				p=strtok(NULL,"/");
				strcpy(nombre,p);
				
				char consulta [500];
				
				strcpy(consulta,"SELECT SUM(RelacionJP.goles) FROM Jugador, RelacionJP WHERE Jugador.nombre='"); 
				strcat(consulta, nombre);
				strcat(consulta,"' AND Jugador.id=RelacionJP.id_J;");
				
				
				err=mysql_query(conn, consulta);
				if (err!=0) 
				{
					sprintf(respuesta, "ERROR");
				}
				else
				{
					resultado = mysql_store_result(conn);
					
					row = mysql_fetch_row(resultado);
					
					if (row == NULL)
						sprintf(respuesta,"NO EXISTE");
					else
					{
						// la columna 1 contiene una palabra que son los goles
						// la convertimos a entero 
						golesresultado= atoi(row[0]); 
						sprintf(respuesta,"%d",golesresultado);
					}
				}
			}
				write(sock_conn,respuesta, strlen(respuesta));
		}

		// Se acabo el servicio para este cliente
		close(sock_conn);
		exit(0);
}
}
