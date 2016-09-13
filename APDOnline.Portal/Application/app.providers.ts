import { bind } from '@angular/core';
import { HTTP_PROVIDERS } from '@angular/http';
import { NotificationService } from './shared/utils/notification.service';

export const APP_PROVIDERS = [   
    NotificationService,
    HTTP_PROVIDERS
];