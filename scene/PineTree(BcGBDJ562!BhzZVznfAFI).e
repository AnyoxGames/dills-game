13
4501125726209
405033722551990 1761863328927056200
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 11.8716182708740234,
    "Y": -10.9883174896240234
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405032364293167:1761863328610581100",
  "next_sibling": "405036083831244:1761863329477237400",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405033722781051:1761863328927109000",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "405033722908718:1761863328927138800",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405033722781051:1761863328927109000",
    "DefaultRenderer": "405033722957394:1761863328927150100",
    "DepletedRenderer": "405033722941226:1761863328927146300"
  }
},
{
  "cid": 5,
  "aoid": "405033722920930:1761863328927141600",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
