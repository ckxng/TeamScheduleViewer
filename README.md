[![.NET](https://github.com/ckxng/TeamScheduleViewer/actions/workflows/dotnet.yml/badge.svg)](https://github.com/ckxng/TeamScheduleViewer/actions/workflows/dotnet.yml)

TeamScheduleViewer
==================

A Planning Center Online schedule viewer for plans in a service group
## Author

[Cameron King](http://cameronking.me)

## Dev Deployment

This project supports the usual ASP.NET deployment targets, plus Windows Docker images.

Additionally, as a single-process app, this project can be deployed to Heroku using a 
.NET 5 buildpack, as follows.

Download and install the [Heroku CLI](https://devcenter.heroku.com/articles/heroku-command-line).

Run:

    heroku login

From within this project directory, run:

    heroku create
    heroku buildpacks:set jincod/dotnetcore
    heroku config:set PCO_ApplicationID="SAMPLE33c8fa441663dce2aeb55aef067ed9a44fcea935252095c8f64c1d0527"
    heroku config:set PCO_Secret="SAMPLEcb39772fd9d9141b554dc8df384286579e71078bdc150290e1e3106b01"
    heroku config:set PCO_ServiceTypeID="1130876"
    git push heroku master

## License

This software is released under the ISC License.

See `LICENSE.txt` file for details.
