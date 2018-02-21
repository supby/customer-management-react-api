var webpack = require('webpack');
var path = require('path');

var BUILD_DIR = path.resolve(__dirname, 'wwwroot', 'dist');
var APP_DIR = path.resolve(__dirname, 'ClientApp');

var config = {
  entry: APP_DIR + '/index.js',
  output: {
    path: BUILD_DIR,
    filename: 'bundle.js',
    publicPath: '/dist/'
  },
  module: {
      rules: [
          {
              test: /\.css$/,
              use: ['style-loader', 'css-loader']
          },
          {
              test: /\.js$/,
              exclude: /node_modules/,
              include: APP_DIR,
              loader: 'babel-loader',
              query: {
                  presets: ['es2015', 'react', 'stage-0']
              }
          }
      ],
  }
};

module.exports = config;