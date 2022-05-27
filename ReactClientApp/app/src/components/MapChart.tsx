import { memo, useContext } from "react";
import {
  ComposableMap,
  Geographies,
  Geography,
  Sphere,
  Graticule
} from "react-simple-maps";
import { AppContext } from "../state/AppContext";

const geoUrl =
  "https://raw.githubusercontent.com/zcreativelabs/react-simple-maps/master/topojson-maps/world-110m.json";

export interface IMapChartProps {
  setTooltipContent: (content: string) => void
}

const MapChart = ({ setTooltipContent } : IMapChartProps) => {
  const context = useContext(AppContext)

  const currentCountry = (location: string ) => {
    const country = context?.allCasesAmount && 
                      context?.allCasesAmount
                      .find(e => location.toLocaleLowerCase().includes(e.location.toLocaleLowerCase()))
    return country                     
  }

  const toolTipStringBuilder = (location: string) => {
    const country = currentCountry(location)
    const cases = country?.variantItems && country?.variantItems.map(e => `<div>${e.name}: ${e.amount}</div>`).join().replaceAll(',', ' ')    
    return cases
  }
  return (
    <>
      <ComposableMap data-tip="" projectionConfig={{ scale: 150 }}>
          <Sphere stroke="#E4E5E6" strokeWidth={0.5} id="sphere" fill="none" />
          <Graticule stroke="#E4E5E6" strokeWidth={0.5} />
          <Geographies geography={geoUrl}>
            {({ geographies }) =>
              geographies.map(geo => (
                <Geography
                  key={geo.rsmKey}
                  geography={geo}
                  onMouseEnter={() => {
                    const { NAME } = geo.properties;
                    setTooltipContent(`<strong>${NAME}</strong> — ${(context?.allCasesAmount && toolTipStringBuilder(NAME)) ?? 'No information'} `);
                  }}
                  onMouseLeave={() => {
                    setTooltipContent("");
                  }}
                  
                  style={{
                    default: {
                      fill: "#D6D6DA",
                      outline: "none"
                    },
                    hover: {
                      fill: "#F53",
                      outline: "none"
                    },
                    pressed: {
                      fill: "#E42",
                      outline: "none"
                    }
                  }}
                />
              ))
            }
          </Geographies>
        
      </ComposableMap>
    </>
  );
};

export default memo(MapChart);
