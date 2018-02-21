import * as React from 'react';

export class Row extends React.Component {
    componentWillMount() {
        this.setState({ isEditMode: this.props.isEditMode, rec: this.props.rec });
    }

    handleEdit() {
        this.setState({ isEditMode: true });
    }

    cancelEdit() {
        this.setState({ isEditMode: false });
    }

    nameChanged(e) {
        const rec = { ...this.state.rec, name: e.target.value}
        this.setState({ ...this.state, rec: rec });
    }

    surnameChanged(e) {
        const rec = { ...this.state.rec, surname: e.target.value}
        this.setState({ ...this.state, rec: rec });
    }

    phoneChanged(e) {
        const rec = { ...this.state.rec, phoneNumber: e.target.value}
        this.setState({ ...this.state, rec: rec });
    }

    addressChanged(e) {
        const rec = { ...this.state.rec, address: e.target.value}
        this.setState({ ...this.state, rec: rec });
    }

    save() {
        this.props.saveRow(this.state.rec);
        this.setState({ isEditMode: false });
    }

    render() {
        return <tr key={this.state.rec.id}>
                            <td>
                                {this.state.isEditMode &&
                                    <input value={this.state.rec.name} 
                                            onChange={this.nameChanged.bind(this)} 
                                            type="text"
                                            className="form-control" />    
                                }
                                {!this.state.isEditMode && this.state.rec.name}
                            </td>
                            <td>
                                {this.state.isEditMode &&
                                    <input value={this.state.rec.surname} 
                                            onChange={this.surnameChanged.bind(this)} 
                                            type="text"
                                            className="form-control" />    
                                }
                                {!this.state.isEditMode && this.state.rec.surname}
                            </td>
                            <td>
                                {this.state.isEditMode &&
                                    <input value={this.state.rec.phoneNumber} 
                                            onChange={this.phoneChanged.bind(this)} 
                                            type="text"
                                            className="form-control" />  
                                }
                                {!this.state.isEditMode && this.state.rec.phoneNumber}
                            </td>
                            <td>
                                {this.state.isEditMode &&
                                    <input value={this.state.rec.address} 
                                            onChange={this.addressChanged.bind(this)} 
                                            type="text"
                                            className="form-control" /> 
                                }
                                {!this.state.isEditMode && this.state.rec.address}
                            </td>
                            <td>
                                { !this.state.isEditMode && 
                                    <button type="button" className="btn btn-primary btn-block" onClick={this.handleEdit.bind(this)}>Edit</button>
                                }
                                { this.state.isEditMode && 
                                    <button type="button" className="btn btn-success btn-block" onClick={this.save.bind(this)}>Save</button>
                                }
                            </td>
                            <td>
                                { !this.state.isEditMode && 
                                    <button type="button" className="btn btn-danger btn-block" onClick={this.props.handleDelete}>Delete</button>
                                }
                                { this.state.isEditMode && 
                                    <button type="button" className="btn btn-primary btn-block" onClick={this.cancelEdit.bind(this)}>Cancel</button>
                                }
                            </td>
                        </tr>;
    }
}