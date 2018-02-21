import * as React from 'react';
import { connect } from 'react-redux'
import { deleteCustomer, actionsCreators, addCustomer } from '../store/actions'
import { Row } from './row'

export class Home extends React.Component {
    componentDidMount() {
        actionsCreators.loadCustomers()(this.props.dispatch);
    }

    handleAdd() {        
        this.props.dispatch(addCustomer());
    }

    handleDelete(index) {
        actionsCreators.deleteCustomer(this.props.customers[index].id, index)(this.props.dispatch);
    }

    saveRow = (row) => {
        actionsCreators.updateCustomer(row)(this.props.dispatch);
    }

    render() {
        const marginTopStyle = {
            marginTop: '50px'
        };

        const marginTopStyle2 = {
            marginTop: '20px'
        };

        return <div className="container" style={marginTopStyle}>
                    <div className="row">
                        <button className="btn btn-primary" onClick={this.handleAdd.bind(this)}>Add Customer</button>
                        <table className="table table-striped" style={marginTopStyle2}>
                            <thead>
                                <tr>
                                    <th>Firstname</th>
                                    <th>Lastname</th>
                                    <th>Phone</th>
                                    <th>Address</th>
                                    <th></th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                {this.props.customers.map((rec, i) => {
                                    return <Row key={rec.id} 
                                                rec={rec}
                                                handleDelete={this.handleDelete.bind(this, i)}
                                                saveRow={this.saveRow}
                                                isEditMode={rec.id <= 0} />
                                })}
                            </tbody>
                        </table>
                    </div>
                </div>;
    }
}

function mapStateToProps(state) {
    return {
        customers: state.customers
    }
}

export default connect(mapStateToProps)(Home)