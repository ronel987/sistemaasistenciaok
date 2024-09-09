import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faEdit, faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';

const url = "http://localhost:8986/api/curso/";
//modal:var q activan los 2 modales
//tipoModal: define con q tipo me encuentro
class ManCurso extends Component {
    state = {
        lista: [],
        modalInsertar: false,
        modalEliminar: false,
        datos: {
            curid: '',
            curestado: 'true',
            curnombre: '',
            grdid: ''
        },
        tipoModal: ''
    }

    metodoGet = () => {
        fetch(url)       //obtiene la lista
            .then(response => {
                return response.json();
            })
            .then(lista => {
                this.setState({  //setea la lista
                    lista
                })
            });
            
    }

    metodoPost = async () => {
        delete this.state.datos.curid;
        await fetch(url, {
            method: "POST",
            body: JSON.stringify(this.state.datos),
            headers: {
                "Content-type": "application/json"
            }
        })
            .then(response => {
                this.modalInsertar();
                this.metodoGet();
            }).catch(error => {
                console.log(error.message);
            })
    }

    metodoPut = () => {
        fetch(url + this.state.datos.curid, {
            method: "PUT",
            body: JSON.stringify(this.state.datos),
            headers: {
                "Content-type": "application/json"
            }
        })
            .then(response => {
                this.modalInsertar();
                this.metodoGet();
            }).catch(error => {
                console.log(error.message);
            })
    }

    metodoDelete = () => {
        fetch(url + this.state.datos.curid, {
            method: "DELETE"
        })
            .then(response => {
                this.setState({
                    modalEliminar: false
                });
                this.metodoGet();
            }).catch(error => {
                console.log(error.message);
            })
    }
   //actualiza la var pa q se muestre u oculte el modal
    modalInsertar = () => {
        this.setState({
            modalInsertar: !this.state.modalInsertar
        });
    }

    seleccionarDatos = (curso) => {    //seleccionar la fila de la tabla
        this.setState({
            tipoModal: 'actualizar',
            datos: {
                curid: curso.curid,
                curestado: curso.curestado,
                curnombre: curso.curnombre,
                grdid: curso.grdid
            }
        });
    }

    cargarDatos = async e => {    //viene del onChange:actualiza valores
        await this.setState({
            datos: {
                ...this.state.datos, [e.target.name]: e.target.value
            }
        });
    }

    componentDidMount() {
        this.metodoGet();
    }
   //AgregarCategoria llamara al Modal
    render() {
        const { datos } = this.state;
        return (
            <main role="main" className="container">
                <div className="row">
                    <button className="btn btn-success mb-4"
                        onClick={() => {
                            this.setState({ datos: null, tipoModal: 'insertar' });
                            this.modalInsertar()
                        }}
                    >Agregar Curso</button>
                </div>
                <div className="row">
                    <div className="col-9">
                        <table className="table">
                            <thead>
                                <tr><th>ID</th><th>Estado</th><th>Nombre</th><th>Grado</th><th>Mantenimiento</th></tr>
                            </thead>
                            <tbody>
                                {this.state.lista.map(curso => {
                                    return (
                                        <tr>
                                            <td>{curso.curid}</td>
                                            <td>{curso.curestado ? 'Activo' : 'Inactivo'}</td>
                                            <td>{curso.curnombre}</td>
                                            <td>{curso.grdid}</td>                                            
                                            <td>
                                                <button className="btn btn-secondary"
                                                    onClick={() => {
                                                        this.seleccionarDatos(curso);
                                                        this.modalInsertar()
                                                    }}>
                                                    <FontAwesomeIcon icon={faEdit} />
                                                </button>
                                                {" "}
                                                <button className="btn btn-danger"
                                                    onClick={() => {
                                                        this.seleccionarDatos(curso);
                                                        this.setState({ modalEliminar: true })
                                                    }}>
                                                    <FontAwesomeIcon icon={faTrashAlt} />
                                                </button>
                                            </td>
                                        </tr>
                                    )
                                })}
                            </tbody>
                        </table>
                          
                        <Modal isOpen={this.state.modalInsertar}>    
                            <ModalHeader style={{ display: 'block' }}>
                                <span style={{ float: 'right' }} onClick={() => this.modalInsertar()}>X</span>
                            </ModalHeader>
                            <ModalBody>
                                <div className="form-group">

                                    <label htmlFor="id">ID</label>
                                    <input className="form-control" type="text" name="curid" id="curid" readOnly
                                        onChange={this.cargarDatos}
                                        value={datos ? datos.curid : ''}></input><br />
                                    
                                    <label htmlFor="estado">Estado (true o false):</label>
                                    <input className="form-control" type="text" name="curestado" id="curestado"
                                        onChange={this.cargarDatos}
                                        value={datos ? datos.curestado : ''}></input>

                                    <label htmlFor="nombre">Nombre:</label>
                                    <input className="form-control" type="text" name="curnombre" id="curnombre"
                                        onChange={this.cargarDatos}
                                        value={datos ? datos.curnombre : ''}></input><br />

                                    <label htmlFor="grado">Grado:</label>
                                    <input className="form-control" type="text" name="grdid" id="grdid"
                                        onChange={this.cargarDatos}
                                        value={datos ? datos.grdid : ''}></input>
                                </div>
                            </ModalBody>
                            <ModalFooter>
                                {this.state.tipoModal == "insertar" ?
                                    <button className="btn btn-seccuess" onClick={() => this.metodoPost()}>
                                        Insertar
                                    </button> : <button className="btn btn-danger" onClick={() => this.metodoPut()}>
                                        Actualizar
                                    </button>
                                }
                            </ModalFooter>
                        </Modal>

                        <Modal isOpen={this.state.modalEliminar}>
                            <ModalBody>
                                Desea Eliminar el Curso {datos && datos.curnombre} ?
                                No Podrás Eliminar Cursos cuyos id esten en CursoDocente!!!
                            </ModalBody>
                            <ModalFooter>
                                <button className="btn btn-danger" onClick={() => this.metodoDelete()}>
                                    Aceptar
                                </button>
                                <button className="btn btn-secondary" onClick={() => this.setState({modalEliminar: false})}>
                                    Cancelar
                                </button>
                            </ModalFooter>
                        </Modal>
                    </div>
                </div>
            </main>
        );
    }
}
//en un solo modal hizo la insercion y actualizacion
export default ManCurso;