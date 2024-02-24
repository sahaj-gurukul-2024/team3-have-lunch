package com.lunch.controller

import com.lunch.dtos.EmployeeAttendanceCountEntry
import com.lunch.service.AdminService
import io.micronaut.core.convert.format.Format
import io.micronaut.http.HttpResponse
import io.micronaut.http.MediaType
import io.micronaut.http.annotation.*
import java.util.Date
import java.text.SimpleDateFormat

@Controller
class AdminController(private val adminService: AdminService) {

    @Get("/admin/{date}")
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    fun getEmployeeCountForDate(@Format("yyyy-MM-dd'T'HH:mm:ss") @PathVariable("date") date: Date): HttpResponse<EmployeeAttendanceCountEntry> {
        return HttpResponse.ok(adminService.getEmployeeCountOnDate(date))
    }

}