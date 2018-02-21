import 'bootstrap/dist/css/bootstrap.min.css';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { AppContainer } from 'react-hot-loader';
import { Provider } from 'react-redux';
import { Router, Route } from 'react-router-dom'
import { createBrowserHistory } from 'history';
import configureStore from './store/index';
import Home from './components/home'

const history = createBrowserHistory();
const initialState = window.initialReduxState;
const store = configureStore(history, initialState);

ReactDOM.render(
    <Provider store={store}>
        <Router history={history}>
            <Route path="/" component={Home} />
        </Router>
    </Provider>,
    document.getElementById('app')
);