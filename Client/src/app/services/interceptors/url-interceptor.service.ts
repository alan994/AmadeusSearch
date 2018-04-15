import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from '../../../environments/environment';

export class UrlInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const host = window.location.host;
    if (req.url.startsWith('/api/')) {
      const newUrl = environment.webApiUrl + req.url;
      const copiedReq = req.clone({ url: newUrl });
      return next.handle(copiedReq);
    }
    else {
      return next.handle(req);
    }
  }
}
