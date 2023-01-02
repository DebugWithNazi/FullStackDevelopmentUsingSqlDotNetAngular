import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { ConfirmBoxEvokeService } from '@costlydeveloper/ngx-awesome-popup';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-edit-customer',
  templateUrl: './add-edit-customer.component.html',
  styleUrls: ['./add-edit-customer.component.css']
})
export class AddEditCustomerComponent implements OnInit {

  form: FormGroup;
  baseUrl: string = ""
  countries: any = [];
  constructor(fb: FormBuilder, private http: HttpClient, @Inject("BASE_URL") url: string,
    private route: ActivatedRoute,
    private toester: ToastrService,
    private router: Router
  ) {
    this.http.get(this.baseUrl + "api/customer/GetCountries").subscribe((res: any) => {
      if (res.status == 1) {
        let data = res.result;
        this.countries = data;
      }
    });
    this.baseUrl = url;
    this.form = fb.group({
      id: null,
      firstName: [null, Validators.required],
      lastName: [null],
      registerationDate: [null],
      address1: [null],
      address2: [null],
      city: [null],
      countryIso: [null]
    });
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      let id = params.get("id");
      if (id != null && id != '') {
        this.editCustomer(id);
      }
    });
  }
  editCustomer(id: any) {
    this.http.get(this.baseUrl + "api/customer/GetById?id=" + id).subscribe((res: any) => {
      if (res.status == 1) {
        let data = res.result;
        this.form.patchValue({
          id: data.id,
          firstName: data.firstName,
          lastName: data.lastName,
          registerationDate: data.registerationDate,
          address1: data.address1,
          address2: data.address2,
          city: data.city,
          countryIso: data.countryIso
        });
      }
    });
  }
  saveData() {
    if (this.form.valid) {
      this.http.post(this.baseUrl + "api/customer/Save", this.form.value).subscribe((res: any) => {
        if (res.status == 1) {
          this.toester.success("record updated Successfully", "Success")
          this.router.navigate(["/"]);
        } else {
          this.toester.error("record noted Saved", "Failed")
        }
      });
    }
  }
}
