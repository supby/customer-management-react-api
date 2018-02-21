export const actionsCreators = {
    loadCustomers: () => {
        return (dispatch) => fetch('api/Customer')
                                .then((res) => res.json())
                                .then((data) => dispatch(loadCustomers(data)));
    },    
    updateCustomer: (customer) => {
        return (dispatch) => {
            let url = 'api/Customer';
            if(customer.id > 0)
                url += '/' + customer.id;
            const method = customer.id > 0 ? 'PUT' : 'POST';

            fetch(url, 
            {
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: method,
                body: JSON.stringify(customer)
            })
            .then((res) => res.json())
            .then((data) => {
                dispatch(updateCustomer(data));
            });
        };
    },
    deleteCustomer: (id, index) => {
        return (dispatch) => {
            if(id > 0) {
                fetch(`api/Customer/${id}`, 
                {
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    method: 'DELETE'
                })
                .then((res) => {
                    dispatch(deleteCustomer(index));
                });
            } else {
                dispatch(deleteCustomer(index));
            }
        };
    }
}

export function loadCustomers(value) {
    return {
        type: 'LOAD_CUSTOMERS',
        value
    }
}

export function addCustomer() {
    return {
        type: 'ADD_CUSTOMER'
    }
}

export function deleteCustomer(value) {
    return {
        type: 'DELETE_CUSTOMER',
        value
    }
}

export function updateCustomer(value) {
    return {
        type: 'UPDATE_CUSTOMER',
        value
    }
}

