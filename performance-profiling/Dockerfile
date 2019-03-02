FROM microsoft/dotnet:2.1.500-sdk AS builder

COPY ./PerformanceProfiling /PerformanceProfiling
WORKDIR /PerformanceProfiling/
RUN dotnet restore
RUN dotnet publish --self-contained -r linux-x64

FROM microsoft/dotnet:2.1.6-runtime AS runtime

RUN apt update
RUN mkdir /perfcoll && cd /perfcoll && curl -OL https://raw.githubusercontent.com/srjohn/corefx-tools/master/src/performance/perfcollect/perfcollect-docker && chmod +x perfcollect-docker
RUN /perfcoll/perfcollect-docker install

ENV COMPlus_PerfMapEnabled 1
ENV COMPlus_EnableEventLog 1

COPY --from=builder /PerformanceProfiling/bin/Debug/netcoreapp2.1/linux-x64/publish app
WORKDIR app
ENTRYPOINT ["dotnet", "PerformanceProfiling.dll"]