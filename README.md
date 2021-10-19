# SamplePhonebookApp

This example demonstrates how to use Asp.net Core MVC technologies with a simple phone book example.

# This example uses the following tools:

## Filters
Filters allow you to perform certain actions before or after a certain stage in the processing of a request. ASP.NET Core provides the following types of filters:

Authorization Filters: Determine if the user is authorized to complete the current request. If the user is not authorized to access the resource, then the filter ends processing the request.

Resource filters: run after authorization filters. Its OnResourceExecuting () method runs before all other filters and before model binding, and its OnResourceExecuted () method runs after all other filters.

Action Filters: Applies only to controller actions, runs after the resource filter, both before and after the controller method is executed

RazorPages Filters: Applies only to RazorPages, executed before and after the request is processed by the Razor Page

Exception filters: define actions on unhandled exceptions

Action Result Filters: The filter is applied to the results of controller methods and Razor Pages, both before and after the result is received

Together, all of these types of filters form a filter pipeline that is built into the MVC process for processing a request and that starts executing after the MVC framework has selected a controller method to process the request. At different stages of processing a request in this pipeline, the corresponding filter is called:

## Authentication and Authorization
ASP.NET Core имеет встроенную поддержку аутентификации на основе куки. Для этого в ASP.NET определен специальный компонент middleware, который сериализует данные пользователя в зашифрованные аутентификационные куки и передает их на сторону клиента. При получении запроса от клиента, в котором содержатся аутентификационные куки, происходит их валидация, десериализация и инициализация свойства User объекта HttpContext.

## ASP.NET Core Identity

ASP.NET Identity is ASP.NET's built-in authentication and authorization system. This system allows users to create accounts, authenticate, manage accounts, or use the accounts of external providers such as Facebook, Google, Microsoft, Twitter and others to log into the site.

## Technologies used
* ul AutoMapper
* ul MailKit (2.15.0)   
* NLog
* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.AspNetCore.Identity.EntityFrameworkCore
