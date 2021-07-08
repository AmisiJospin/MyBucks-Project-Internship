body{
	margin: 0 auto;
	width:1200px;
}

.header{
	height:200px;
	width:100%;
	background: url('flywheel.jpg') no-repeat;
	background-size:100%;

}

.header h1{
	text-align: center;
	color:white;
	text-transform:uppercase;
	margin-top: 10px;
}

nav{
	text-align: center;
	opacity: 0.95;

}

nav a{
	text-decoration:none;
	background: gray;
	opacity: 0.95;
	color:black;
	font-size: 25px;
	border-radius: 10px;
	margin-left: 50px;
	height: 50px;
	width: 120px;
}

.active{
	background: white;
	color:black;
	font-size: 25px;
	border-radius: 20px;
	height: 50px;
	width: 120px;
}

.container{
	width: 100%;
	height: 500px;
	margin-top:0;
	
}

.aside{
	width: 25%;
	float: left;
	background:#76762a;
	padding: 20px;
	
}

.aside img{
	border: 1px solid black;
	height: 130px;
	width: 100%;
	margin-top:10px;
}

.section{
	width: 70%;
	float: right;
}

table{
	border: 2px solid white;
	border-collapse: collapse;
	width:90%;
	margin-left: 30px;
}
//Aligning The First Column
table .left{
	text-align:left;
}

//Aligning remaining colums to the center.
th{
	background:#909f5a;
	color:white;
	text-align: center;
	border: 2px solid green;
	height:20px;
	}

td{
	background:#e2f5d7;
	color:white;
	height:20px;
	text-align: center;
	border: 2px solid white;
}
//The Table Rows Opacity and hover
tr: hover{
	opacity: 0.8;
}