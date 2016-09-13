
///<reference path="../typings/browser.d.ts"/>

import { bootstrap }    from '@angular/platform-browser-dynamic';

import { HTTP_BINDINGS } from '@angular/http';
import { AppComponent } from './application.component';
import { applicationRouterProviders } from './application-routes';

import { enableProdMode } from '@angular/core';

enableProdMode();
bootstrap(AppComponent, [applicationRouterProviders]);
