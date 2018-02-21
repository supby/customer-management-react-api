import { combineReducers } from 'redux';
import { updateCustomer } from '../actions/index';

export function customers(state = [], action) {
    switch (action.type) {
        case 'DELETE_CUSTOMER':
            return state.filter((el,i) => i != action.value);
        case 'UPDATE_CUSTOMER':
            const updatedCustomer = action.value;            
            const index = state.findIndex((el, i) => el.id == updatedCustomer.id);
            
            if(index == -1) {
                return state.filter((el,i) => el.id > 0).concat(updatedCustomer);
            } else {
                return state
                        .filter((el,i) => el.id != updatedCustomer.id && el.id > 0)
                        .concat(updatedCustomer)
                        .sort((a,b) => a.id - b.id);
            }
        case 'ADD_CUSTOMER':
            let minId = 0;
            if(state.length > 0) {
                let minId = state.sort((a,b) => a.id - b.id)[0].id;
                minId = minId <= 0 ? minId - 1 : 0;
            }
            
            return state.concat([{id: minId, name: '', surname: '', phoneNumber: '', address: ''}]).sort((a,b) => a.id - b.id);
        case 'LOAD_CUSTOMERS':
            return action.value;
        default:
            console.log('def');
            return state;
    }
}

export const rootReducer = combineReducers({
    customers
});