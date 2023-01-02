import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ConfirmBoxEvokeService } from '@costlydeveloper/ngx-awesome-popup';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  baseUrl = "";
  filter = "";
  customerList: any = [];
  constructor(private comfirmbox: ConfirmBoxEvokeService,
    private toester: ToastrService,
    private http: HttpClient, @Inject("BASE_URL") url: string) {
    this.baseUrl = url;

  }

  ngOnInit(): void {
    this.loadData();
  }

  delete(id: any) {
    this.comfirmbox.warning("Are you sure you want delete!", "record will be delete form database", "Yes", "No").
      subscribe((res) => {
        if (res.success) {
          this.http.delete(this.baseUrl + "api/customer/DeleteById?id=" + id).subscribe(res => {
            this.loadData();
            this.toester.success("Record Deleted Successfully", "Success!");
          });
        }

      })
  }

  loadData() {
    this.http.get(this.baseUrl + "api/customer/Filter?sortColumn=Id&sortOrder=asc&pageNo=0&pageSize=20&filter=" + this.filter)
      .subscribe((res: any) => {
        if (res.status == 1) {
          this.customerList = res.result.data;
        }
      })
  }
}
